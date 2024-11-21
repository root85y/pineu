namespace Pineu.Application.MainDomain.WorkoutStatuses.Commands {
    public sealed record UpsertWorkoutStatusCommand(Guid UserId, DateTime Date, WorkoutStatusEnum Value) : ICommand;
}
