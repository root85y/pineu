namespace Pineu.Application.MainDomain.Patient.Queries.DTOs {
    public sealed record GetAllWorkoutStatusesForPatientResponse(DateOnly Date, WorkoutStatusEnum Value);
}
