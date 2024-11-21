namespace Pineu.Application.MainDomain.Profiles.Commands.Validators {
    public class UpsertProfileCommandValidator : AbstractValidator<UpsertProfileCommand> {
        public UpsertProfileCommandValidator() {
            RuleFor(p => p.UserId).NotEmpty();
        }
    }
}
