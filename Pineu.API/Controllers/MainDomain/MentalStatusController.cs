using Pineu.API.DTOs.MainDomain.MentalStatuses;
using Pineu.Application.MainDomain.MentalStatuses.Commands;
using Pineu.Application.MainDomain.MentalStatuses.Queries;
using Pineu.Application.MainDomain.MentalStatuses.Queries.DTOs;
using Pineu.Application.MainDomain.Patient.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain {
    public class MentalStatusController(ISender sender) : ApiController(sender) {
        [HttpPut, Authorize]
        public async Task<IActionResult> Upsert([FromBody] UpsertMentalStatusRequest request, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var command = new UpsertMentalStatusCommand(Guid.Parse(userId), request.Values, request.Date);
            var res = await Sender.Send(command, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse();
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<GetMentalStatusResponse>> Get([FromQuery] DateTime? date, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetMentalStatusByUserIdAndDateQuery(Guid.Parse(userId), date);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return SuccessResponse();

            return SuccessResponse(res.Value.Value);
        }
        [HttpGet, Route("All"), Authorize]
        public async Task<ActionResult<PagedResponse<IEnumerable<GetAllMentalStatusesResponse>>>> GetAll([FromQuery] DateTime? from, DateTime? to,
            [FromQuery] PaginationRequest pagination, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetAllMentalStatusesQuery(from, to, pagination.Page, pagination.PageSize, Guid.Parse(userId));
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpGet, Route("Chart"), Authorize]
        public async Task<ActionResult<GetMentalStatusChartResponse>> GetChart([FromQuery] DateTime? from, DateTime? to, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetMentalStatusesChartQuery(from, to, Guid.Parse(userId));
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
    }
}
