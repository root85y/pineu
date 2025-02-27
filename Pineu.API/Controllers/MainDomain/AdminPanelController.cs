using Microsoft.IdentityModel.Tokens;
using Pineu.API.Constants;
using Pineu.API.DTOs.Auth.Permissions;
using Pineu.Application.MainDomain.DoctorPrescriptions.Queries;
using Pineu.Application.MainDomain.MedicalInformations.Queries.DTOs;
using Pineu.Application.MainDomain.MedicalInformations.Queries;
using Pineu.Application.MainDomain.Profiles.Queries;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Pineu.Application.MainDomain.AdminPanel.Queries;
using Pineu.Application.MainDomain.Doctor.Queries;

namespace Pineu.API.Controllers.MainDomain
{
    public class AdminPanelController(ISender sender) : ApiController(sender)
    {


        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request.Username == "Admin")
                if (request.Password == "root")
                    return Ok(new
                    {
                        Token = await CreateToken()
                    });
                else
                    return BadRequest(new
                    {
                        Masseage = "Password wrong"
                    });
            else
                return BadRequest(new
                {
                    Masseage = "Username wrong"
                });
        }

        [HttpPost, Route("GetUserCount")]
        public async Task<IActionResult> GetUserCount(CancellationToken cancellationToken)
        {
            var query = new GetProfileCountQuery();
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure)
                return HandleFailure(res);

            return Ok(res.Value);
        }

        [HttpPost, Authorize, Route("GetUserNotRegisteredCount")]
        public async Task<IActionResult> GetUserNotRegisteredCount(CancellationToken cancellationToken)
        {

            var query = new GetAllUserQuery("waiting");
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure)
                return HandleFailure(res);

            return Ok(res.Value.Count);
        }

        [HttpPost, Route("GetDoctorCount")]
        public async Task<IActionResult> GetDoctorCount(CancellationToken cancellationToken)
        {
            var query = new GetDoctorCountQuery();
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure)
                return HandleFailure(res);

            return Ok(res.Value);
        }

        [HttpPost, Route("GetDoctorData")]
        public async Task<IActionResult> GetDoctorData(CancellationToken cancellationToken)
        {
            var query = new GetDoctorDataQuery();
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure)
                return HandleFailure(res);

            PersianCalendar persianCalendar = new();

            var doctorsList = res.Value.List.Select(doctor => new
            {
                doctor.FirstName,
                doctor.LastName,
                doctor.Mobile,
                doctor.NationalCode,
                doctor.PersonnelCode,
                doctor.Id,
                CreatedAt = $"{persianCalendar.GetYear(doctor.CreatedAt):0000}/{persianCalendar.GetMonth(doctor.CreatedAt):00}/{persianCalendar.GetDayOfMonth(doctor.CreatedAt):00}",
                UpdatedAt = $"{persianCalendar.GetYear(doctor.UpdatedAt):0000}/{persianCalendar.GetMonth(doctor.UpdatedAt):00}/{persianCalendar.GetDayOfMonth(doctor.UpdatedAt):00}",
            }).ToList();

            return Ok(doctorsList);
        }

        [HttpPost, Route("GetUserData")]
        public async Task<IActionResult> GetUserData(CancellationToken cancellationToken)
        {
            var query = new GetUserDataQuery();
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure)
                return HandleFailure(res);

            PersianCalendar persianCalendar = new();
            string doctorname = "";
            ////var UserList = res.Value.List.Select(user => new
            ////{
            ////    user.Id,
            ////    user.FullName,
            ////    user.Mobile,
            ////    user.DoctorId,
            ////    //DoctorName = GetNameOfDoctorWithId(user.DoctorId ?? Guid.Empty, cancellationToken),
            ////    //DoctorName = user.DoctorId == Guid.Empty ? "نامعلوم" : GetNameOfDoctorWithId(user.DoctorId, cancellationToken),
            ////    DoctorName = user.DoctorId == null || user.DoctorId == Guid.Empty ? "نامعلوم" : GetNameOfDoctorWithId(user.DoctorId.Value, cancellationToken),
            ////    user.Gender,
            ////    user.MaritalStatus,
            ////    user.Birthdate,
            ////    CreatedAt = $"{persianCalendar.GetYear(user.CreatedAt):0000}/{persianCalendar.GetMonth(user.CreatedAt):00}/{persianCalendar.GetDayOfMonth(user.CreatedAt):00}",
            ////    UpdatedAt = $"{persianCalendar.GetYear(user.UpdatedAt):0000}/{persianCalendar.GetMonth(user.UpdatedAt):00}/{persianCalendar.GetDayOfMonth(user.UpdatedAt):00}",

            ////}).ToList();
            var UserList = await Task.WhenAll(res.Value.List.Select(async user => new
            {
                user.Id,
                user.FullName,
                user.Mobile,
                user.DoctorId,
                DoctorName = user.DoctorId == null || user.DoctorId == Guid.Empty
        ? ".هنوز دکتری ثبت نشده است."
        : await GetNameOfDoctorWithId(user.DoctorId.Value, cancellationToken),
                user.Gender,
                user.MaritalStatus,
                user.Birthdate,
                CreatedAt = $"{persianCalendar.GetYear(user.CreatedAt):0000}/{persianCalendar.GetMonth(user.CreatedAt):00}/{persianCalendar.GetDayOfMonth(user.CreatedAt):00}",
                UpdatedAt = $"{persianCalendar.GetYear(user.UpdatedAt):0000}/{persianCalendar.GetMonth(user.UpdatedAt):00}/{persianCalendar.GetDayOfMonth(user.UpdatedAt):00}",
            }));



            return Ok(UserList);
        }

        [HttpPost, Route("GetUserNotRegisteredData")]
        public async Task<IActionResult> GetUserNotRegisteredData(CancellationToken cancellationToken)
        {
            var query = new GetUserNotRegisteredDataQuery("waiting");
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure)
                return HandleFailure(res);

            PersianCalendar persianCalendar = new();

            var UserList = res.Value.List.Select(user => new
            {
                user.Id,
                user.FullName,
                user.Mobile,
                user.DoctorId,
                user.Gender,
                user.MaritalStatus,
                user.Birthdate,
                CreatedAt = $"{persianCalendar.GetYear(user.CreatedAt):0000}/{persianCalendar.GetMonth(user.CreatedAt):00}/{persianCalendar.GetDayOfMonth(user.CreatedAt):00}",
                UpdatedAt = $"{persianCalendar.GetYear(user.UpdatedAt):0000}/{persianCalendar.GetMonth(user.UpdatedAt):00}/{persianCalendar.GetDayOfMonth(user.UpdatedAt):00}",

            }).ToList();

            return Ok(UserList);
        }


        #region bac
        private async Task<string> CreateToken()
        {

            var signingCredential = GetSigningCredential();
            var tokenOptions = GenerateTokenOptions(signingCredential);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredential, List<Claim> claims = null)
        {
            if (claims != null)
            {
                var expireTime = DateTime.Now.AddDays(Convert.ToDouble(JwtConfigs.JwtExpire));

                var token = new JwtSecurityToken(
                    issuer: JwtConfigs.JwtIssuer,
                    claims: claims,
                    expires: expireTime,
                    signingCredentials: signingCredential
                );

                return token;
            }
            else
            {
                var expireTime = DateTime.Now.AddDays(Convert.ToDouble(JwtConfigs.JwtExpire));

                var token = new JwtSecurityToken(
                    issuer: JwtConfigs.JwtIssuer,
                    expires: expireTime,
                    signingCredentials: signingCredential
                );

                return token;
            }
        }

        private SigningCredentials GetSigningCredential()
        {
            var key = JwtConfigs.JwtKey;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public static int CalculateAge(DateTime birthDate)
        {
            bool isPersianDate = birthDate.Year < 1900;

            int birthYear;
            if (isPersianDate)
            {
                PersianCalendar persianCalendar = new PersianCalendar();
                birthYear = persianCalendar.ToDateTime(birthDate.Year, birthDate.Month, birthDate.Day, 0, 0, 0, 0).Year;
            }
            else
            {
                birthYear = birthDate.Year;
            }

            int currentYear = DateTime.Now.Year;
            int age = currentYear - birthYear;

            DateTime adjustedBirthDate = new DateTime(currentYear, birthDate.Month, birthDate.Day);
            if (DateTime.Now < adjustedBirthDate)
            {
                age--;
            }

            return age;
        }

        //GetMedicalInformationsAsync
        private async Task<(string? Message, GetMedicalInformationResponse)> GetMedicalInformationsAsync(
            Guid patientId,
            CancellationToken cancellationToken)
        {
            var query = new GetMedicalInformationByUserIdQuery(patientId);
            var result = await Sender.Send(query, cancellationToken);
            if (result.IsFailure)
            {
                return (result.Error.ToString(), null);
            }
            return (null, result.Value);
        }

        private async Task<string> GetNameOfDoctorWithId(Guid DoctorId, CancellationToken cancellationToken)
        {
            if (DoctorId != Guid.Empty || DoctorId.ToString().Length < 5)
            {
                var query = new GetNameOfDoctorWithIdQuery(DoctorId);
                var result = await Sender.Send(query, cancellationToken);
                if (result.IsFailure)
                {
                    return (result.Error.ToString());
                }
                return (result.Value);
            }
            else
                return ("هنوز دکتری ثبت نشده است.");

        }
        #endregion
    }
}