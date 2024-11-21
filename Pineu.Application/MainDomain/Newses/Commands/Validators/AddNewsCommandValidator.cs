namespace Pineu.Application.MainDomain.Newses.Commands.Validators {
    public class AddNewsCommandValidator : AbstractValidator<AddNewsCommand> {
        public AddNewsCommandValidator() {
            RuleFor(n => n.Title).NotEmpty();
            RuleFor(n => n.Body).NotEmpty();
            RuleFor(n => n.Link).NotEmpty();
            RuleFor(n => n.ImageId).NotEmpty();
        }
    }
}
