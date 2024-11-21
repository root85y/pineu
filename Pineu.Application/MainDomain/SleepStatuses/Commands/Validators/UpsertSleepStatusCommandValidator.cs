namespace Pineu.Application.MainDomain.SleepStatuses.Commands.Validators {
    public class UpsertSleepStatusCommandValidator : AbstractValidator<UpsertSleepStatusCommand> {
        public UpsertSleepStatusCommandValidator() {
            RuleFor(ss => DateOnly.FromDateTime(ss.Date)).NotEmpty().GreaterThan(DateOnly.FromDateTime(DateTime.Now.AddDays(-3)))
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now));
            RuleFor(ss => ss.UserId).NotEmpty();
            RuleFor(ss => ss.Value).IsInEnum();
        }
    }
}
