namespace Pineu.Application.MainDomain.Discounts.Commands.Validators;
public class AddDiscountCommandValidator : AbstractValidator<AddDiscountCommand> {
    public AddDiscountCommandValidator() {
        RuleFor(d => d.Description).NotEmpty();
        RuleFor(d => d.Title).NotEmpty();
        RuleFor(d => d.OffPercentage).NotEmpty().GreaterThan(0).LessThanOrEqualTo(100);
        RuleFor(d => d.ExpiresAt).NotEmpty();
        RuleFor(d => d.ScoreCost).NotEmpty();
        RuleFor(d => d.StoreId).NotEmpty();
    }
}
