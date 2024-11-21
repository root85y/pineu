using Pineu.Application.MainDomain.Profiles.Commands;

namespace Pineu.Application.MainDomain.Profiles.Commands.Validators {
    public class UpsertDoctorCommandValidator : AbstractValidator<UpsertProfileCommand> {
        public UpsertDoctorCommandValidator() {
            RuleFor(p => p.UserId).NotEmpty();
        }
    }
}