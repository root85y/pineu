namespace Pineu.Application.MainDomain.Newses.Commands.Validators {
    public class RemoveNewsCommandValidator : AbstractValidator<RemoveNewsCommand> {
        public RemoveNewsCommandValidator() {
            RuleFor(n => n.Id);
        }
    }
}
