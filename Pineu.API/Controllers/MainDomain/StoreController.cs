using Pineu.Application.MainDomain.Stores.Queries;
using Pineu.Application.MainDomain.Stores.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain {
    public class StoreController(ISender sender) : ApiController(sender) {
        [HttpGet, Route("All")]
        public async Task<ActionResult<PagedResponse<IEnumerable<GetAllStoresResponse>>>> GetAll([FromQuery] PaginationRequest pagination, [FromQuery] string? search, CancellationToken cancellationToken) {
            var query = new GetAllStoresQuery(pagination.Page, pagination.PageSize, search);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
    }
}
