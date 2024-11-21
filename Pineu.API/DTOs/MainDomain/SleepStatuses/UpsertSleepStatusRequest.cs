namespace Pineu.API.DTOs.MainDomain.SleepStatuses {
    public sealed record UpsertSleepStatusRequest(DateTime Date, SleepStatusEnum Value);
}
