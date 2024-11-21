namespace Pineu.Application.MainDomain.UserIngredients.Commands.Validators {
    public class UpdateUserIngredientCommandValidator : AbstractValidator<UpdateUserIngredientCommand> {
        public UpdateUserIngredientCommandValidator() {
            RuleFor(ui => ui.Id).NotEmpty();
            RuleFor(ui => ui.UserId).NotEmpty();
            RuleFor(ui => ui.Name).NotEmpty();
            RuleFor(ui => ui.Category).IsInEnum();
        }
    }
}
