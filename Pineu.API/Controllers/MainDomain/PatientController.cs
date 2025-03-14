﻿using Pineu.API.DTOs.Auth;
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
using System.Globalization;
using Pineu.Application.MainDomain.Seizures.Queries;
using Pineu.Application.MainDomain.Seizures.Queries.DTOs;
using Pineu.Domain.Entities.MainDomain;
using Shared;
using Pineu.Application.MainDomain.Profiles.Queries.DTOs;
using Google.Protobuf;
using Pineu.Application.MainDomain.Doctor.Queries;
using Newtonsoft.Json;

namespace Pineu.API.Controllers.MainDomain {
    public class PatientController(ISender sender, ISmsPool smsPool, ISmsPanel smsPanel, UserManager<User> userManager) : ApiController(sender) {
        [HttpPost, Route("PatientRegistration")]
        public async Task<IActionResult> PatientRegistration([FromBody] PatientRegistrationRequest request, CancellationToken cancellationToken) {
            var query = new GetProfileByPhonenumberQuery(request.PhoneNumber);
            var res = await Sender.Send(query, cancellationToken);
            if (res.Error.Message == "پروفایل یافت نشد") {

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
            } else {

                var userId = HttpContext.User.Identity.Name;
                var query1 = new GetLestOfRegPatientQuery(Guid.Parse(userId), "Completed");
                var res1 = await Sender.Send(query1, cancellationToken);
                var query2 = new GetLestOfRegPatientQuery(Guid.Parse(userId), "waiting");
                var res2 = await Sender.Send(query2, cancellationToken);
                if (res1.IsFailure)
                    return HandleFailure(res1);
                if (res2.IsFailure)
                    return HandleFailure(res2);
                if ((res1.Value.Count == 0) && (res2.Value.Count == 0)) {
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
                } else {
                    return BadRequest(new {
                        Message = "This patient is already in your list"
                    });
                }
            }
        }

        [HttpPost, Authorize, Route("PatientRegistrationValidateCode")]
        public async Task<IActionResult> PatientRegistrationValidateCode([FromBody] ValidateCodeRequest request, CancellationToken cancellationToken) {
            if (!request.PhoneNumber.StartsWith("09") || request.PhoneNumber.Length != 11)
                return BadRequest(new {
                    Message = "الگو شمارۀ موبایل وارد شده اشتباه است"
                });

            var code = await smsPool.GetCode(request.PhoneNumber);
            var date = await smsPool.GetDate(request.PhoneNumber);
            if (code != request.Code)
                return BadRequest(new {
                    Message = "کد اشتباه است"
                });
            if (date.HasValue && date.Value.AddMinutes(2) < DateTime.Now)
                return BadRequest(new {
                    Message = "کد منقضی شده است"
                });

            await smsPool.RemoveCode(request.PhoneNumber);
            await smsPool.RemoveDate(request.PhoneNumber);

            var username = HttpContext.User.Identity.Name;

            var (IsSuccess, massge) = await AddDoctorIdToPatient(
                request.PhoneNumber,
                Guid.Parse(username),
                cancellationToken);
            if (!IsSuccess)
                return BadRequest(new { Massge = massge });

            return Ok(new {
                Message = "با موفقیت به بیماران شما اضافه شد"
            });
        }

        [HttpGet, Authorize, Route("PatientsRegistered")]
        public async Task<IActionResult> PatientsRegistered(CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;
            string typeofepilepsy = "";

            var query = new GetLestOfRegPatientQuery(Guid.Parse(userId), "Completed");
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure)
                return HandleFailure(res);

            var res2 = res.Value.List.Select(patient => new {
                patient.patientid,
                patient.FullName,
                patient.PhoneNumber,
                Age = patient.Birthdate.HasValue ? CalculateAge(patient.Birthdate.Value) : (int?)null,
                patient.Create
            });


            //var patientIds = res.Value.List.Select(patient => patient.patientid).ToList();

            //foreach (var patientId in patientIds) {
            //    var (Message5, resMedicalInformations) = await GetMedicalInformationsAsync(patientId, cancellationToken);
            //    if (resMedicalInformations == null)
            //        return BadRequest(new { Error_Message = Message5 });

            //    switch (resMedicalInformations.EpilepsyType) {
            //        case 1:
            //            typeofepilepsy = "فوکال";
            //            break;
            //        case 2:
            //            typeofepilepsy = "ژنرالیزه";

            //            break;
            //        case 3:
            //            typeofepilepsy = "ترکیب فوکال و ژنرالیزه";
            //            break;
            //        case 4:
            //            typeofepilepsy = "ناشناخته";
            //            break;
            //    }

            //    res2.Select(pa => new {
            //        pa.patientid,
            //        pa.FullName,
            //        pa.PhoneNumber,
            //        pa.Age,
            //        EpilepsyType = typeofepilepsy,
            //        pa.Create
            //    });
            //}

            return SuccessResponse(res2);
        }

        [HttpGet, Authorize, Route("PatientsNotRegistered")]
        public async Task<IActionResult> PatientsNotRegistered(CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetLestOfRegPatientQuery(Guid.Parse(userId), "waiting");
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure)
                return HandleFailure(res);

            return SuccessResponse(res.Value);
        }

        [HttpGet, Authorize, Route("GetPatientsData")]
        public async Task<IActionResult> GetPatientsData(
            [FromQuery] DateTime? From, DateTime? To,string PhoneNumber, CancellationToken cancellationToken) {
            var doctordata = HttpContext.User.Identity.Name;

            var patinetId = await userManager.FindByNameAsync(PhoneNumber);

            //var patinetId2 = await GetPatinetIdWithPhoneNumberAsync(PhoneNumber);


            var query = new GetAllPatientDataQuery(patinetId.Id, Guid.Parse(doctordata));
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure)
                return HandleFailure(res);

            var (Message, resSleepStatuse) = await GetSleepStatusesAsync(From, To, patinetId.Id, cancellationToken);
            if (resSleepStatuse == null)
                return BadRequest(new {
                    Error_Message = Message
                });

            var (Message2, resNutritionStatus) = await GetNutritionStatusAsync(From, To, patinetId.Id, cancellationToken);
            if (resNutritionStatus == null)
                return BadRequest(new {
                    Error_Message = Message2
                });

            var (Message3, resMentalStatus) = await GetMentalStatusAsync(From, To, patinetId.Id, cancellationToken);
            if (resMentalStatus == null)
                return BadRequest(new {
                    Error_Message = Message3
                });

            var (Message4, resSeizures) = await GetSeizuresAsync(From, To, patinetId.Id, cancellationToken);
            if (resSeizures == null)
                return BadRequest(new {
                    Error_Message = Message4
                });
            var (Message5, resMedicalInformations) = await GetMedicalInformationsAsync(patinetId.Id, cancellationToken);
            if (resMedicalInformations == null)
                return BadRequest(new {
                    Error_Message = Message5
                });

            var (Message6, resWorkoutStatus) = await GetWorkoutStatusAsync(From, To, patinetId.Id, cancellationToken);
            if (resWorkoutStatus == null)
                return BadRequest(new {
                    Error_Message = Message6
                });



            return Ok(new {
                UserId = res.Value.userId,
                DoctorId = res.Value.doctorId,
                DoctorName = GetNameOfDoctorWithId(res.Value.doctorId ?? Guid.Empty, cancellationToken).Result,
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

        
        [HttpGet, Authorize, Route("Dashboard")]
        public async Task<IActionResult> GetPatientsData([FromQuery]
            DateTime? From,
            DateTime? To,
            CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var PatientsNotRegisteredQuery = new GetLestOfRegPatientQuery(Guid.Parse(userId), "waiting");
            var PatientsNotRegisteredRes = await Sender.Send(PatientsNotRegisteredQuery, cancellationToken);

            var PatientsRegisteredQuery = new GetLestOfRegPatientQuery(Guid.Parse(userId), "Completed");
            var PatientsRegisteredRes = await Sender.Send(PatientsRegisteredQuery, cancellationToken);

            var (Message, Epilepsy) = await GetEpilepsyAsync(cancellationToken);
            if (Epilepsy == null)
                return BadRequest(new {
                    Error_Message = Message
                });

            var query = new GetAllPatientQuery(Guid.Parse(userId), "Completed");
            var res = await Sender.Send(query, cancellationToken);

            var patientDtos = res.Value.List.Select(p => new {
                p.FullName,
                p.Gender,
                p.Birthdate,
                p.MaritalStatus,
                p.Mobile,
                p.Score,
                DoctorName = GetNameOfDoctorWithId(p.DoctorId ?? Guid.Empty, cancellationToken).Result,
                p.Status,
                p.UserId
            });

            int TodaySeizures = 0;
            var SeizuresCount = new List<object>();

            foreach (var PatientData in res.Value.List) {
                var (Message2, Today_Seizures) = await GetTodaySeizuresAsync(Guid.Parse(userId), PatientData, cancellationToken);
                if (Message2 != null)
                    return BadRequest(new { masage = Message2 });


                TodaySeizures += Today_Seizures;
            }

            foreach (var PatientData in res.Value.List) {
                var (Message3, AllSeizuresCount) = await GetAllSeizuresCountAsync(Guid.Parse(userId), PatientData, From, To, cancellationToken);
                if (Message3 != null)
                    return BadRequest(new { masage = Message3 });

                SeizuresCount.Add(new {
                    SeizuresCount = AllSeizuresCount
                });

            }

            return Ok(new {
                PatientsNotRegisteredRes,
                PatientsRegisteredRes,
                Epilepsy,
                TodaySeizures,
                SeizuresCount,
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

            if (previousCode.HasValue)
                await smsPool.RemoveCode(PhoneNumber);
            if (previousDate.HasValue)
                await smsPool.RemoveDate(PhoneNumber);

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

            var Status = res.Value.status;

            await Sender.Send(new UpdateProfileCommand(
            DoctorId, Status, res.Value.UserID ?? Guid.Empty), cancellationToken);

            return (true, "Success");
        }

        //GetSleepStatusesAsync
        private async Task<(string? Message, PagedResponse<IEnumerable<object>>)> GetSleepStatusesAsync(
            DateTime? sleepStatusFrom,
            DateTime? SleepStatusTo,
            Guid patientId,
            CancellationToken cancellationToken) {
            var query = new GetAllSleepStatusesForPatiantQuery(sleepStatusFrom, SleepStatusTo, patientId);
            var result = await Sender.Send(query, cancellationToken);
            if (result.IsFailure) {
                return (result.Error.ToString(), null);
            }

            var formattedResult = result.Value.List.Select(status => new
            {
                status.Date,
                SleepStatus = status.Value.ToString() 
            }).ToList();


            return (null, new PagedResponse<IEnumerable<object>>(formattedResult, formattedResult.Count));
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
        private async Task<(string? Message, PagedResponse<IEnumerable<object>>)> GetMentalStatusAsync(
            DateTime? From,
            DateTime? To,
            Guid patientId,
            CancellationToken cancellationToken) {
            var query = new GetAllMentalStatusesForPatientQuery(From, To, patientId);
            var result = await Sender.Send(query, cancellationToken);
            if (result.IsFailure) {
                return (result.Error.ToString(), null);
            }

            var formattedResult = result.Value.List.Select(status => new {
                status.Date,
                MentalStatuses = status.Value
            }).ToList();

            return (null, new PagedResponse<IEnumerable<object>>(formattedResult, formattedResult.Count));
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

        //GetNameOfDoctorWithId
        private async Task<string> GetNameOfDoctorWithId(
            Guid DoctorId,
            CancellationToken cancellationToken) {
            if (DoctorId != Guid.Empty) {
                var query = new GetNameOfDoctorWithIdQuery(DoctorId);
                var result = await Sender.Send(query, cancellationToken);
                if (result.IsFailure) {
                    return (result.Error.ToString());
                }
                return (result.Value);
            }
            else
                return ("هنوز دکتری ثبت نشده است");

        }

        //GetEpilepsyAsync
        private async Task<(string? Message, List<object>)> GetEpilepsyAsync(CancellationToken cancellationToken) {
            var query = new GetEpilepsyQuery();
            var result = await Sender.Send(query, cancellationToken);
            if (result.IsFailure) {
                return (result.Error.ToString(), null);
            }
            return (null, result.Value);
        }

        //GetTodaySeizuresAsync
        private async Task<(string? Message, int)> GetTodaySeizuresAsync(Guid DoctorId, Profile PatientData, CancellationToken cancellationToken) {
            var query = new GetTodeySeizuresQuery(DoctorId, PatientData);
            var result = await Sender.Send(query, cancellationToken);
            if (result.IsFailure) {
                return (result.Error.ToString(), 0);
            }
            return (null, result.Value);
        }

        //GetAllSeizuresCountAsync
        private async Task<(string? Message, PagedResponse<IEnumerable<GetAllSeizuresResponse>>)> GetAllSeizuresCountAsync(Guid DoctorId, Profile PatientData, DateTime? form, DateTime? to, CancellationToken cancellationToken) {
            var query = new GetAllSeizuresCountQuery(DoctorId, PatientData, form, to);
            var result = await Sender.Send(query, cancellationToken);
            if (result.IsFailure) {
                return (result.Error.ToString(), null);
            }
            return (null, result.Value);
        }

        //private async Task<Guid> GetPatinetIdWithPhoneNumberAsync(string PhoneNumber, CancellationToken cancellationToken) {
        //    var query = new GetPatinetIdWithPhoneNumberQuery(PhoneNumber);
        //    var result = await Sender.Send(query, cancellationToken);
        //    if (result.IsFailure) {
        //        return (result.Error.ToString(), null);
        //    }
        //    return (result.Value);
        //}

        //GetWorkoutStatusAsync
        private async Task<(string? Message, PagedResponse<IEnumerable<object>>)> GetWorkoutStatusAsync(
            DateTime? From,
            DateTime? To,
            Guid patientId,
            CancellationToken cancellationToken) {
            var query = new GetAllWorkoutStatusesForPatientQuery(From, To, patientId);
            var result = await Sender.Send(query, cancellationToken);
            if (result.IsFailure) {
                return (result.Error.ToString(), null);
            }

            var formattedResult = result.Value.List.Select(status => new {
                status.Date,
                WorkoutStatuses = status.Value.ToString()
            }).ToList();

            return (null, new PagedResponse<IEnumerable<object>>(formattedResult, formattedResult.Count));
        }


        public static int CalculateAge(DateTime birthDate) {
            bool isPersianDate = birthDate.Year < 1900;

            int birthYear;
            if (isPersianDate) {
                PersianCalendar persianCalendar = new PersianCalendar();
                birthYear = persianCalendar.ToDateTime(birthDate.Year, birthDate.Month, birthDate.Day, 0, 0, 0, 0).Year;
            } else {
                birthYear = birthDate.Year;
            }

            int currentYear = DateTime.Now.Year;
            int age = currentYear - birthYear;

            DateTime adjustedBirthDate = new DateTime(currentYear, birthDate.Month, birthDate.Day);
            if (DateTime.Now < adjustedBirthDate) {
                age--;
            }

            return age;
        }
        #endregion
    }
}
