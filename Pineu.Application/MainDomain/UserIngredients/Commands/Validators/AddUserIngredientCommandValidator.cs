namespace Pineu.Application.MainDomain.UserIngredients.Commands.Validators {
    public class AddUserIngredientCommandValidator : AbstractValidator<AddUserIngredientCommand> {
        public AddUserIngredientCommandValidator() {
            RuleFor(ui => ui.UserId).NotEmpty();
            RuleFor(ui => ui.Name).NotEmpty();
            RuleFor(ui => ui.Category).IsInEnum();
        }
    }
}
