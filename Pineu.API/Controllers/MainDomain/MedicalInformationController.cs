using Pineu.Application.MainDomain.MedicalInformations.Commands;
using Pineu.Application.MainDomain.MedicalInformations.Queries;
using Pineu.Application.MainDomain.MedicalInformations.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain {
    public class MedicalInformationController(ISender sender) : ApiController(sender) {
        [HttpPut, Authorize]
        public async Task<IActionResult> Upsert([FromBody] UpsertMedicalInformationRequest request, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var command = new UpsertMedicalInformationCommand(Guid.Parse(userId), request);
            var res = await Sender.Send(command, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse();
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<GetMedicalInformationResponse>> Get(CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetMedicalInformationByUserIdQuery(Guid.Parse(userId));
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return SuccessResponse();

            return SuccessResponse(res.Value);
        }
    }
}
