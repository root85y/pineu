namespace Pineu.Application.MainDomain.Banners.Queries.DTOs;
public sealed record GetAllBannerResponse(Guid Id, string Title, string Link, string ImageUrl);
