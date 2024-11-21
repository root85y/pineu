using Pineu.API.DTOs.MainDomain.Profiles;
using Pineu.Application.MainDomain.Profiles.Commands;
using Pineu.Application.MainDomain.Profiles.Queries;
using Pineu.Application.MainDomain.Profiles.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain
{
    public class ProfileController(ISender sender, UserManager<User> userManager) : ApiController(sender)
    {
        [HttpPut, Authorize]
        public async Task<IActionResult> Upsert([FromBody] UpdateProfileRequest request, CancellationToken cancellationToken)
        {
            var userId = HttpContext.User.Identity.Name;

            var command = new UpsertProfileCommand(request.FullName, request.Gender, request.Birthdate, request.MaritalStatus, null, request.PhoneNumber, request.DoctorId, "Completed", Guid.Parse(userId));
            var res = await Sender.Send(command, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse();
        }
        [HttpGet, Authorize]
        public async Task<ActionResult<GetProfileResponse>> Get(CancellationToken cancellationToken)
        {
            var userId = HttpContext.User.Identity.Name;

            var user = await userManager.FindByIdAsync(userId);
            var query = new GetProfileByUserIdQuery(Guid.Parse(userId), user.PhoneNumber!);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
    }
}
