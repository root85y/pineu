using Pineu.API.DTOs.Auth;
using Pineu.API.DTOs.MainDomain.Patient;
using Pineu.Application.Abstractions.Pools;
using Pineu.Application.Abstractions.Sms;
using Pineu.Application.MainDomain.Profiles.Commands;
using Pineu.Application.MainDomain.Profiles.Queries;
using Pineu.Application.MainDomain.Patient.Queries;
using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.MedicalInformations.Queries;
using Pineu.Persistence.AuthEntities;
using Pineu.Application.MainDomain.MedicalInformations.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain {
    public class PatientController(ISender sender, ISmsPool smsPool, ISmsPanel smsPanel, UserManager<User> userManager) : ApiController(sender) {
        [HttpPost, Route("PatientRegistration")]
        public async Task<IActionResult> PatientRegistration([FromBody] PatientRegistrationRequest request, CancellationToken cancellationToken) {
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber, cancellationToken: cancellationToken);


            if (user == null) {

                await sender.Send(new UpsertProfileCommand(request.FullName, null, null, null, null, request.PhoneNumber, null, "waiting", Guid.NewGuid()), cancellationToken);

                var (IsSuccess, Meessage, code) = await SendSms(request.PhoneNumber, true);
                if (!IsSuccess)
                    return NotFound(new {
                        Message = Meessage
                    });

                return Accepted(new {
                    Message = Meessage,
                    Code = code,
                    request.PhoneNumber
                });
            }
            else {
                var (IsSuccess, Meessage, code) = await SendSms(request.PhoneNumber, true);
                if (!IsSuccess)
                    return NotFound(new {
                        Message = Meessage
                    });

                return Accepted(new {
                    Message = Meessage,
                    Code = code,
                    request.PhoneNumber,
                });
            }
        }

        [HttpPost, Authorize, Route("PatientRegistrationValidateCode")]
        public async Task<IActionResult> PatientRegistrationValidateCode([FromBody] ValidateCodeRequest request, CancellationToken cancellationToken) {
            if (!request.PhoneNumber.StartsWith("09") || request.PhoneNumber.Length != 11) return BadRequest(new {
                Message = "الگو شمارۀ موبایل وارد شده اشتباه است"
            });

            var code = await smsPool.GetCode(request.PhoneNumber);
            var date = await smsPool.GetDate(request.PhoneNumber);
            if (code != request.Code) return BadRequest(new {
                Message = "کد اشتباه است"
            });
            if (date.HasValue && date.Value.AddMinutes(2) < DateTime.Now) return BadRequest(new {
                Message = "کد منقضی شده است"
            });

            await smsPool.RemoveCode(request.PhoneNumber);
            await smsPool.RemoveDate(request.PhoneNumber);

            var username = HttpContext.User.Identity.Name;

            var (IsSuccess, massge) = await AddDoctorIdToPatient(request.PhoneNumber, Guid.Parse(username), cancellationToken);
            if (!IsSuccess)
                return BadRequest(new { Massge = massge });

            return Ok(new {
                Message = "با موفقیت به بیماران شما اضافه شد"
            });
        }

        [HttpGet, Authorize, Route("PatientsRegistered")]
        public async Task<IActionResult> PatientsRegistered(CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetLestOfRegPatientQuery(Guid.Parse(userId), "Completed");
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }

        [HttpGet, Authorize, Route("PatientsNotRegistered")]
        public async Task<IActionResult> PatientsNotRegistered(CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetLestOfRegPatientQuery(Guid.Parse(userId), "waiting");
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }

        [HttpGet, Route("GetPatientsData")]
        public async Task<IActionResult> GetPatientsData(
            [FromQuery] DateTime? From, DateTime? To, string PhoneNumber, CancellationToken cancellationToken) {
            var doctordata = HttpContext.User.Identity.Name;

            var patinetId = await userManager.FindByNameAsync(PhoneNumber);


            var query = new GetAllPatientDataQuery(patinetId.Id, Guid.Parse(doctordata));
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            var (Message, resSleepStatuse) = await GetSleepStatusesAsync(From, To, patinetId.Id, cancellationToken);
            if (resSleepStatuse == null)
                return BadRequest(new {
                    Error_Message = Message
                });

            var (Message2, resNutritionStatus) = await GetNutritionStatusAsync(From, To, patinetId.Id, cancellationToken);
            if (resSleepStatuse == null)
                return BadRequest(new {
                    Error_Message = Message2
                });

            var (Message3, resMentalStatus) = await GetMentalStatusAsync(From, To, patinetId.Id, cancellationToken);
            if (resSleepStatuse == null)
                return BadRequest(new {
                    Error_Message = Message3
                });

            var (Message4, resSeizures) = await GetSeizuresAsync(From, To, patinetId.Id, cancellationToken);
            if (resSleepStatuse == null)
                return BadRequest(new {
                    Error_Message = Message4
                });
            var (Message5, resMedicalInformations) = await GetMedicalInformationsAsync(patinetId.Id, cancellationToken);
            if (resSleepStatuse == null)
                return BadRequest(new {
                    Error_Message = Message5
                });

            var (Message6, resWorkoutStatus) = await GetWorkoutStatusAsync(From, To, patinetId.Id, cancellationToken);
            if (resSleepStatuse == null)
                return BadRequest(new {
                    Error_Message = Message6
                });



            return Ok(new {
                UserId = res.Value.userId,
                DoctorId = res.Value.doctorId,
                FullName = res.Value.fullName,
                Gender = res.Value.gender,
                Birthdate = res.Value.birthdate,
                MaritalStatus = res.Value.maritalStatus,
                PhoneNumber = res.Value.Mobile,
                Status = res.Value.status,
                SleepStatuse = resSleepStatuse,
                NutritionStatus = resNutritionStatus,
                MentalStatus = resMentalStatus,
                Seizures = resSeizures,
                WorkoutStatus = resWorkoutStatus,
                MedicalInformations = resMedicalInformations
            });
        }

        #region bac
        private async Task<(bool IsSuccess, string? Message, int? Code)> SendSms(string PhoneNumber, bool NewUser) {
            var apiKey = Environment.GetEnvironmentVariable("SmsPanelApiKey");
            var templateId = Environment.GetEnvironmentVariable("SmsPanelTemplateIdSendCode");

            if (NewUser)
                templateId = Environment.GetEnvironmentVariable("SmsPanelTemplateIdSendLink");
            else
                templateId = Environment.GetEnvironmentVariable("SmsPanelTemplateIdSendCode");

            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(templateId))
                return (false, "سرویس پیامکی به صورت موقت از دسترس خارج است. لطفا بعداً اقدام کنید.", null);

            if (!PhoneNumber.StartsWith("09") || PhoneNumber.Length != 11)
                return (false, "الگو شمارۀ موبایل وارد شده اشتباه است", null);

            var previousCode = await smsPool.GetCode(PhoneNumber);
            var previousDate = await smsPool.GetDate(PhoneNumber);

            if (previousCode.HasValue) await smsPool.RemoveCode(PhoneNumber);
            if (previousDate.HasValue) await smsPool.RemoveDate(PhoneNumber);

            Random random = new();
            int code = random.Next(100000, 999999);

            if (!await smsPool.AddCode(PhoneNumber, code))
                return (false, "لطفا دوباره تلاش کنید", null);
            var dateTime = DateTime.Now;
            if (!await smsPool.AddDate(PhoneNumber, dateTime))
                return (false, "لطفا دوباره تلاش کنید", null);

            await smsPanel.SendSms(PhoneNumber, code, apiKey, Convert.ToInt32(templateId));
            return (true, "با موفقیت ارسال شد", code);
        }

        private async Task<(bool IsSuccess, string Message)> AddDoctorIdToPatient(string PhoneNumber, Guid DoctorId, CancellationToken cancellationToken) {
            var query = new GetProfileByPhonenumberQuery(PhoneNumber!);
            var res = await Sender.Send(query, cancellationToken);
            await Sender.Send(new UpdateProfileCommand(DoctorId, res.Value.UserID ?? Guid.Empty), cancellationToken);

            return (true, "Success");
        }

        //GetSleepStatusesAsync
        private async Task<(string? Message, PagedResponse<IEnumerable<GetAllSleepStatForPatientResponse>>)> GetSleepStatusesAsync(
            DateTime? sleepStatusFrom,
            DateTime? SleepStatusTo,
            Guid patientId,
            CancellationToken cancellationToken) {
            var query = new GetAllSleepStatusesForPatiantQuery(sleepStatusFrom, SleepStatusTo, patientId);
            var result = await Sender.Send(query, cancellationToken);
            if (result.IsFailure) {
                return (result.Error.ToString(), null);
            }
            return (null, result.Value);
        }

        //GetNutritionStatusAsync
        private async Task<(string? Message, PagedResponse<IEnumerable<GetAllNutritionStatusesForPatientResponse>>)> GetNutritionStatusAsync(
            DateTime? From,
            DateTime? To,
            Guid patientId,
            CancellationToken cancellationToken) {
            var query = new GetAllNutritionStatusesForPatientQuery(From, To, patientId);
            var result = await Sender.Send(query, cancellationToken);
            if (result.IsFailure) {
                return (result.Error.ToString(), null);
            }
            return (null, result.Value);
        }
        //GetMentalStatusAsync
        private async Task<(string? Message, PagedResponse<IEnumerable<GetAllMentalStatusesForPatientResponse>>)> GetMentalStatusAsync(
            DateTime? From,
            DateTime? To,
            Guid patientId,
            CancellationToken cancellationToken) {
            var query = new GetAllMentalStatusesForPatientQuery(From, To, patientId);
            var result = await Sender.Send(query, cancellationToken);
            if (result.IsFailure) {
                return (result.Error.ToString(), null);
            }
            return (null, result.Value);
        }

        //GetSeizuresAsync
        private async Task<(string? Message, PagedResponse<IEnumerable<GetAllSeizuresForPatientResponse>>)> GetSeizuresAsync(
            DateTime? From,
            DateTime? To,
            Guid patientId,
            CancellationToken cancellationToken) {
            var query = new GetAllSeizuresForPatientQuery(From, To, patientId);
            var result = await Sender.Send(query, cancellationToken);
            if (result.IsFailure) {
                return (result.Error.ToString(), null);
            }
            return (null, result.Value);
        }

        //GetMedicalInformationsAsync
        private async Task<(string? Message, GetMedicalInformationResponse)> GetMedicalInformationsAsync(
        Guid patientId,
    CancellationToken cancellationToken) {
            var query = new GetMedicalInformationByUserIdQuery(patientId);
            var result = await Sender.Send(query, cancellationToken);
            if (result.IsFailure) {
                return (result.Error.ToString(), null);
            }
            return (null, result.Value);
        }
        //GetWorkoutStatusAsync
        private async Task<(string? Message, PagedResponse<IEnumerable<GetAllWorkoutStatusesForPatientResponse>>)> GetWorkoutStatusAsync(
    DateTime? From,
    DateTime? To,
    Guid patientId,
    CancellationToken cancellationToken) {
            var query = new GetAllWorkoutStatusesForPatientQuery(From, To, patientId);
            var result = await Sender.Send(query, cancellationToken);
            if (result.IsFailure) {
                return (result.Error.ToString(), null);
            }
            return (null, result.Value);
        }
        #endregion
    }
}
