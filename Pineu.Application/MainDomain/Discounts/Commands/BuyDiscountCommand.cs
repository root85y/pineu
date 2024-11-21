
namespace Pineu.Application.MainDomain.Discounts.Commands;
public sealed record BuyDiscountCommand(Guid UserId, Guid DiscountId) : ICommand<string>;
