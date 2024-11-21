namespace Pineu.API.DTOs.MainDomain.WorkoutStatuses {
    public sealed record UpsertWorkoutStatusRequest(DateTime Date, WorkoutStatusEnum Value);
}
