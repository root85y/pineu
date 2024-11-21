namespace Pineu.Application.MainDomain.UserDiscounts.Commands.Validators {
    public class AddUserDiscountCommandValidator : AbstractValidator<AddUserDiscountCommand> {
        public AddUserDiscountCommandValidator() {
            RuleFor(ud => ud.UserId).NotEmpty();
            RuleFor(ud => ud.DiscountId).NotEmpty();
        }
    }
}
