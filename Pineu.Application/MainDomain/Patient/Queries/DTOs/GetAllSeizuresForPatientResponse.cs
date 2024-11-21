namespace Pineu.Application.MainDomain.Patient.Queries.DTOs {
    public sealed record GetAllSeizuresForPatientResponse(DateTime SeizureDateTime, int? SeizureDuration);
}
