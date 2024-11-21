namespace Pineu.Application.MainDomain.Discounts.Queries.DTOs;
public sealed record GetDiscountResponse(
    Guid Id,
    string Title,
    string Description,
    int OffPercentage,
    DateTime ExpiresAt,
    int ScoreCost,
    string StoreName,
    string StoreImageUrl,
    string StorePhoneNumber,
    string StoreAddress);
