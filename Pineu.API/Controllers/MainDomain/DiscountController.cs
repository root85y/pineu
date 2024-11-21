using Pineu.API.DTOs.Primitives;
using Pineu.Application.MainDomain.Discounts.Commands;
using Pineu.Application.MainDomain.Discounts.Queries;
using Pineu.Application.MainDomain.Discounts.Queries.DTOs;

namespace Pineu.API.Controllers.MainDomain {
    public class DiscountController(ISender sender) : ApiController(sender) {
        [HttpGet, Route("All")]
        public async Task<ActionResult<PagedResponse<IEnumerable<GetAllDiscountResponse>>>> GetAll([FromQuery] PaginationRequest pagination, [FromQuery] Guid? storeId, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity?.Name;
            Guid? userGuid = userId != null ? Guid.Parse(userId) : null;

            var query = new GetAllDiscountsQuery(null, pagination.Page, pagination.PageSize, storeId, userGuid);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpGet]
        public async Task<ActionResult<GetDiscountResponse>> GetById([FromQuery] Guid id, CancellationToken cancellationToken) {
            var query = new GetDiscountByIdQuery(id);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpPost, Route("Buy"), Authorize]
        public async Task<IActionResult> Buy([FromQuery] Guid id, CancellationToken cancellationToken) {
            var userId = HttpContext.User.Identity.Name;

            var query = new BuyDiscountCommand(Guid.Parse(userId), id);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }

    }
}
