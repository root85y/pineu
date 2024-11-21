using Pineu.Application.MainDomain.Discounts.Queries.DTOs;

namespace Pineu.Application.MainDomain.Discounts.Queries.Handlers;
internal class GetAllDiscountsQueryHandler(IDiscountRepository repository)
    : IQueryHandler<GetAllDiscountsQuery, PagedResponse<IEnumerable<GetAllDiscountResponse>>> {
    public async Task<Result<PagedResponse<IEnumerable<GetAllDiscountResponse>>>> Handle(GetAllDiscountsQuery request, CancellationToken cancellationToken) {
        var discounts = await repository.GetAllAsync(request.Search, request.Page, request.PageSize, request.StoreId, request.UserId, cancellationToken);

        var res = discounts.List.Select(d => new GetAllDiscountResponse(d.Id, d.Title, d.OffPercentage, d.ExpiresAt, d.ScoreCost));
        return new PagedResponse<IEnumerable<GetAllDiscountResponse>>(res, discounts.Count);
    }
}
