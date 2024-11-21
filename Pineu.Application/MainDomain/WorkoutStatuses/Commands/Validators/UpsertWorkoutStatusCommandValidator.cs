namespace Pineu.Application.MainDomain.WorkoutStatuses.Commands.Validators {
    public class UpsertWorkoutStatusCommandValidator : AbstractValidator<UpsertWorkoutStatusCommand> {
        public UpsertWorkoutStatusCommandValidator() {
            RuleFor(ws => ws.UserId).NotEmpty();
            RuleFor(ws => DateOnly.FromDateTime(ws.Date)).NotEmpty().GreaterThan(DateOnly.FromDateTime(DateTime.Now.AddDays(-3)))
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now));
            RuleFor(ws => ws.Value).IsInEnum();
        }
    }
}
