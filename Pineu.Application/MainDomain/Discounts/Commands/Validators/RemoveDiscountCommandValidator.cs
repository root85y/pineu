namespace Pineu.Application.MainDomain.Discounts.Commands.Validators;
public class RemoveDiscountCommandValidator : AbstractValidator<RemoveDiscountCommand> {
    public RemoveDiscountCommandValidator() {
        RuleFor(d => d.Id).NotEmpty();
    }
}
