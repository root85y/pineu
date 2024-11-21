using Pineu.Application.MainDomain.Banners.Queries.DTOs;

namespace Pineu.Application.MainDomain.Banners.Queries;
public sealed record GetAllBannersQuery(int? Page, int? PageSize, string? Search)
    : IQuery<PagedResponse<IEnumerable<GetAllBannerResponse>>>;
