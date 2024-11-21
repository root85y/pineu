namespace Pineu.Application.MainDomain.SleepStatuses.Queries.DTOs {
    public sealed record GetSleepStatusChartResponse(DateTime Date, SleepStatusEnum SleepStatus, bool HasSeizureHappened);
}
