using Pineu.Application.MainDomain.DoctorPrescriptions.Queries;
using Pineu.Application.MainDomain.Profiles.Queries;
using System.Globalization;

namespace Pineu.API.Controllers.MainDomain {
    public class AdminPanelController(ISender sender) : ApiController(sender) {

        [HttpPost, Route("GetUserCount")]
        public async Task<IActionResult> GetUserCount(CancellationToken cancellationToken) {
            var query = new GetProfileCountQuery();
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure)
                return HandleFailure(res);

            return Ok(res.Value);
        }
        [HttpPost, Route("GetDoctorCount")]
        public async Task<IActionResult> GetDoctorCount(CancellationToken cancellationToken) {
            var query = new GetDoctorCountQuery();
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure)
                return HandleFailure(res);

            return Ok(res.Value);
        }
        [HttpPost, Route("GetDoctorData")]
        public async Task<IActionResult> GetDoctorData(CancellationToken cancellationToken) {
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
        public async Task<IActionResult> GetUserData(CancellationToken cancellationToken) {
            var query = new GetUserDataQuery();
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure)
                return HandleFailure(res);

            PersianCalendar persianCalendar = new();

            var UserList = res.Value.List.Select(user => new {
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
        }s
    }
}