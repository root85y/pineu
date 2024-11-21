using Pineu.Application.MainDomain.Banners.Queries;
using Pineu.Application.MainDomain.Banners.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain {
    public class BannerController(ISender sender) : ApiController(sender) {

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<GetAllBannerResponse>>>> GetAll([FromQuery] PaginationRequest pagination, CancellationToken cancellationToken) {
            var query = new GetAllBannersQuery(pagination.Page, pagination.PageSize, null);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
    }
}
