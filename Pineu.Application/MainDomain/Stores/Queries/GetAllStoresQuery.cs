using Pineu.Application.MainDomain.Stores.Queries.DTOs;

namespace Pineu.Application.MainDomain.Stores.Queries {
    public sealed record GetAllStoresQuery(int? Page, int? PageSize, string? Search)
        : IQuery<PagedResponse<IEnumerable<GetAllStoresResponse>>>;
}
