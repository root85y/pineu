namespace Pineu.Application.MainDomain.Discounts.Commands;
public sealed record AddDiscountCommand(
    string Title,
    string Description,
    int OffPercentage,
    DateTime ExpiresAt,
    int ScoreCost,
    Guid StoreId) : ICommand<Guid>;
