namespace Pineu.Application.MainDomain.Discounts.Queries.DTOs;
public sealed record GetAllDiscountResponse(Guid Id, string Title, int OffPercentage, DateTime ExpiresAt, int ScoreCost);
