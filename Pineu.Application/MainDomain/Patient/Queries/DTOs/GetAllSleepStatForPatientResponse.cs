namespace Pineu.Application.MainDomain.Patient.Queries.DTOs {
    public sealed record GetAllSleepStatForPatientResponse(
        DateOnly Date,
        SleepStatusEnum Value
        );
}
