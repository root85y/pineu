namespace Pineu.Application.MainDomain.MentalStatuses.Commands.Validators {
    public class UpsertMentalStatusCommandValidator : AbstractValidator<UpsertMentalStatusCommand> {
        public UpsertMentalStatusCommandValidator() {
            RuleFor(m => m.UserId).NotEmpty();
            RuleFor(m => DateOnly.FromDateTime(m.Date)).NotEmpty().GreaterThan(DateOnly.FromDateTime(DateTime.Now.AddDays(-3)))
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now));
            RuleForEach(m => m.Value).IsInEnum();
        }
    }
}
