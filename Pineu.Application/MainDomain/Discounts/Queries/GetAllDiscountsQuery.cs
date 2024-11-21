using Pineu.Application.MainDomain.Discounts.Queries.DTOs;

namespace Pineu.Application.MainDomain.Discounts.Queries;
public sealed record GetAllDiscountsQuery(string? Search, int? Page, int? PageSize, Guid? StoreId, Guid? UserId)
    : IQuery<PagedResponse<IEnumerable<GetAllDiscountResponse>>>;
