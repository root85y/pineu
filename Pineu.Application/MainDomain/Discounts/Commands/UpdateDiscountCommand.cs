namespace Pineu.Application.MainDomain.Discounts.Commands;
public sealed record UpdateDiscountCommand(
    Guid Id,
    string Title,
    string Description,
    int OffPercentage,
    DateTime ExpiresAt,
    int ScoreCost,
    Guid StoreId) : ICommand;
