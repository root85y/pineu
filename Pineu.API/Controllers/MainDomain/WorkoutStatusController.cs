using Pineu.API.DTOs.MainDomain.WorkoutStatuses;
using Pineu.Application.MainDomain.WorkoutStatuses.Commands;
using Pineu.Application.MainDomain.WorkoutStatuses.Queries;
using Pineu.Application.MainDomain.WorkoutStatuses.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain {
    public class WorkoutStatusController(ISender sender) : ApiController(sender) {
        [HttpPut, Authorize]
        public async Task<IActionResult> Upsert([FromBody] UpsertWorkoutStatusRequest request, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var command = new UpsertWorkoutStatusCommand(Guid.Parse(userId), request.Date, request.Value);
            var res = await Sender.Send(command, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse();
        }
        [HttpGet, Authorize]
        public async Task<ActionResult<GetWorkoutStatusResponse>> Get([FromQuery] DateTime? date, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetWorkoutStatusByUserIdQuery(Guid.Parse(userId), date);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return SuccessResponse();

            return SuccessResponse(res.Value.Value);
        }
        [HttpGet, Route("All"), Authorize]
        public async Task<ActionResult<PagedResponse<IEnumerable<GetAllWorkoutStatusesResponse>>>> GetAll([FromQuery] DateTime? from, DateTime? to,
            [FromQuery] PaginationRequest pagination, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetAllWorkoutStatusesQuery(Guid.Parse(userId), from, to, pagination.Page, pagination.PageSize);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpGet, Route("Chart"), Authorize]
        public async Task<ActionResult<PagedResponse<IEnumerable<GetWorkoutStatusChartResponse>>>> GetChart([FromQuery] DateTime? from, DateTime? to, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetWorkoutStatusesChartQuery(Guid.Parse(userId), from, to);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
    }
}
