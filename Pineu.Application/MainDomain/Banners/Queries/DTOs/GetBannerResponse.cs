namespace Pineu.Application.MainDomain.Banners.Queries.DTOs;
public sealed record GetBannerResponse(Guid Id, string Title, string Link, Guid ImageId);
