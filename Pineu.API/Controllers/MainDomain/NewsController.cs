using Pineu.Application.MainDomain.Newses.Queries;
using Pineu.Application.MainDomain.Newses.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain {
    public class NewsController(ISender sender) : ApiController(sender) {
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<GetAllNewsResponse>>>> GetAll([FromQuery] PaginationRequest pagination, CancellationToken cancellationToken) {
            var query = new GetAllNewsQuery(null, pagination.Page, pagination.PageSize);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
    }
}
