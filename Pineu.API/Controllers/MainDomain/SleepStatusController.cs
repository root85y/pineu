using Pineu.API.DTOs.MainDomain.SleepStatuses;
using Pineu.Application.MainDomain.SleepStatuses.Commands;
using Pineu.Application.MainDomain.SleepStatuses.Queries;
using Pineu.Application.MainDomain.SleepStatuses.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain {
    public class SleepStatusController(ISender sender) : ApiController(sender) {
        [HttpPut, Authorize]
        public async Task<IActionResult> Upsert([FromBody] UpsertSleepStatusRequest request, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var command = new UpsertSleepStatusCommand(Guid.Parse(userId), request.Date, request.Value);
            var res = await Sender.Send(command, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse();
        }
        [HttpGet, Authorize]
        public async Task<ActionResult<GetSleepStatusResponse>> Get([FromQuery] DateTime? date, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetSleepStatusByUserIdQuery(Guid.Parse(userId), date);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return SuccessResponse();

            return SuccessResponse(res.Value.Value);
        }

        [HttpGet, Route("All"), Authorize]
        public async Task<ActionResult<PagedResponse<IEnumerable<GetAllSleepStatusesResponse>>>> GetAll([FromQuery] DateTime? from, DateTime? to,
            [FromQuery] PaginationRequest pagination, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetAllSleepStatusesQuery(from, to, pagination.Page, pagination.PageSize, Guid.Parse(userId));
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpGet, Route("Chart"), Authorize]
        public async Task<ActionResult<PagedResponse<IEnumerable<GetSleepStatusChartResponse>>>> GetChart([FromQuery] DateTime? from, DateTime? to, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetSleepStatusesChartQuery(Guid.Parse(userId), from, to);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
    }
}
