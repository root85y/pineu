namespace Pineu.Application.MainDomain.WorkoutStatuses.Queries.DTOs {
    public sealed record GetWorkoutStatusChartResponse(DateTime Date, WorkoutStatusEnum WorkoutStatus, bool HasSeizureHappened);
}
