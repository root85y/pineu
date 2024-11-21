using Pineu.Application.MainDomain.UserDiscounts.Queries;
using Pineu.Application.MainDomain.UserDiscounts.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain {
    public class UserDiscountController(ISender sender) : ApiController(sender) {
        [HttpGet, Route("All"), Authorize]
        public async Task<ActionResult<PagedResponse<IEnumerable<GetAllUserDiscountResponse>>>> GetAll([FromQuery] PaginationRequest pagination, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new GetAllUserDiscountsQuery(pagination.Page, pagination.PageSize, Guid.Parse(userId));
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
    }
}
