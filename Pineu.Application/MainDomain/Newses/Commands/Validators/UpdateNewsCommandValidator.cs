namespace Pineu.Application.MainDomain.Newses.Commands.Validators {
    public class UpdateNewsCommandValidator : AbstractValidator<UpdateNewsCommand> {
        public UpdateNewsCommandValidator() {
            RuleFor(n => n.Id).NotEmpty();
            RuleFor(n => n.Title).NotEmpty();
            RuleFor(n => n.Body).NotEmpty();
            RuleFor(n => n.Link).NotEmpty();
            RuleFor(n => n.ImageId).NotEmpty();
        }
    }
}
