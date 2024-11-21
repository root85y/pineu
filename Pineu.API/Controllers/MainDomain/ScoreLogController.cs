using Pineu.Application.MainDomain.ScoreLogs.Queries;
using Pineu.Application.MainDomain.ScoreLogs.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain {
    public class ScoreLogController(ISender sender) : ApiController(sender) {
        [HttpGet, Route("All"), Authorize]
        public async Task<ActionResult<PagedResponse<IEnumerable<GetAllScoreLogsResponse>>>> GetAll([FromQuery] PaginationRequest pagination,
            [FromQuery] DateTime? from, DateTime? to, ScoreType? scoreType, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetAllScoreLogsQuery(from, to, pagination.Page, pagination.PageSize, Guid.Parse(userId), scoreType);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }

        [HttpGet, Route("Summary"), Authorize]
        public async Task<ActionResult<GetUsersScoreSummeryResponse>> Summary(CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetUsersScoreSummeryQuery(Guid.Parse(userId));
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
    }
}
