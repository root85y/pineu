namespace Pineu.Application.MainDomain.SleepStatuses.Queries.DTOs {
    public sealed record GetAllSleepStatusesResponse(DateOnly Date, SleepStatusEnum Value, bool HasSeizureHappened);
}
