using Pineu.Application.MainDomain.Newses.Queries.DTOs;

namespace Pineu.Application.MainDomain.Newses.Queries {
    public sealed record GetAllNewsQuery(string? Search, int? Page, int? PageSize)
        : IQuery<PagedResponse<IEnumerable<GetAllNewsResponse>>>;
}
