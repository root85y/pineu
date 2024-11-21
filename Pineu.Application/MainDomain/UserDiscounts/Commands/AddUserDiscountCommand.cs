namespace Pineu.Application.MainDomain.UserDiscounts.Commands {
    public sealed record AddUserDiscountCommand(Guid DiscountId, Guid UserId) : ICommand<string>;
}
