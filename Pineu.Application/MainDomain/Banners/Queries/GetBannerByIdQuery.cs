using Pineu.Application.MainDomain.Banners.Queries.DTOs;

namespace Pineu.Application.MainDomain.Banners.Queries;
public sealed record GetBannerByIdQuery(Guid Id) : IQuery<GetBannerResponse>;
