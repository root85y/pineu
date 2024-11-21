namespace Pineu.Application.MainDomain.SleepStatuses.Commands {
    public sealed record UpsertSleepStatusCommand(Guid UserId, DateTime Date, SleepStatusEnum Value) : ICommand;
}
