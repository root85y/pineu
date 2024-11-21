namespace Pineu.Application.MainDomain.Seizures.Queries.DTOs {
    public sealed record GetAllSeizuresResponse(DateTime SeizureDateTime, int? SeizureDuration);
}
