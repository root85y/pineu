namespace Pineu.Application.MainDomain.Discounts.Commands.Validators;
public class BuyDiscountCommandValidator : AbstractValidator<BuyDiscountCommand> {
    public BuyDiscountCommandValidator() {
        RuleFor(d => d.UserId).NotEmpty();
        RuleFor(d => d.DiscountId).NotEmpty();
    }
}
