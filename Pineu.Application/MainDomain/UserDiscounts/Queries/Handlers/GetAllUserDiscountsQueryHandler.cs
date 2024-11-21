using Pineu.Application.MainDomain.UserDiscounts.Queries.DTOs;

namespace Pineu.Application.MainDomain.UserDiscounts.Queries.Handlers {
    internal class GetAllUserDiscountsQueryHandler(IUserDiscountRepository repository)
        : IQueryHandler<GetAllUserDiscountsQuery, PagedResponse<IEnumerable<GetAllUserDiscountResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetAllUserDiscountResponse>>>> Handle(GetAllUserDiscountsQuery request, CancellationToken cancellationToken) {
            var userDiscounts = await repository.GetAllAsync(request.Page, request.PageSize, request.UserId, cancellationToken);

            var res = userDiscounts.List.Select(ud => new GetAllUserDiscountResponse(
                ud.DiscountCode,
                ud.Discount.Title,
                ud.Discount.OffPercentage,
                (DateTime.Now - ud.CreatedAt).TotalHours > 24));
            return new PagedResponse<IEnumerable<GetAllUserDiscountResponse>>(res, userDiscounts.Count);
        }
    }
}
