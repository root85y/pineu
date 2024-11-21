using Pineu.API.DTOs.MainDomain.DoctorPrescriptions;
using Pineu.Application.MainDomain.DoctorPrescriptions.Commands;
using Pineu.Application.MainDomain.DoctorPrescriptions.Queries;
using Pineu.Application.MainDomain.DoctorPrescriptions.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain {
    public class DoctorPrescriptionController(ISender sender) : ApiController(sender) {
        [HttpPost, Authorize]
        public async Task<IActionResult> Create([FromBody] AddDoctorPrescriptionRequest request, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var command = new AddDoctorPrescriptionCommand(Guid.Parse(userId), request.DoctorName, request.VisitContent, request.VisitedAt);
            var res = await Sender.Send(command, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }

        [HttpGet, Route("All"), Authorize]
        public async Task<ActionResult<PagedResponse<IEnumerable<GetAllDoctorPrescriptionsResponse>>>> GetAll([FromQuery] DateTime? from, DateTime? to,
            [FromQuery] PaginationRequest pagination, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetAllDoctorPrescriptionsQuery(Guid.Parse(userId), from, to, pagination.Page, pagination.PageSize);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
    }
}
