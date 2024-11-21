using Pineu.Application.MainDomain.UserDiscounts.Queries.DTOs;

namespace Pineu.Application.MainDomain.UserDiscounts.Queries {
    public sealed record GetAllUserDiscountsQuery(int? Page, int? PageSize, Guid UserId) : IQuery<PagedResponse<IEnumerable<GetAllUserDiscountResponse>>>;
}
