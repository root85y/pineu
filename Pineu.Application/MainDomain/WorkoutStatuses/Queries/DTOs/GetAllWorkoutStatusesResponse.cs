namespace Pineu.Application.MainDomain.WorkoutStatuses.Queries.DTOs {
    public sealed record GetAllWorkoutStatusesResponse(DateOnly Date, WorkoutStatusEnum Value, bool HasSeizureHappened);
}
