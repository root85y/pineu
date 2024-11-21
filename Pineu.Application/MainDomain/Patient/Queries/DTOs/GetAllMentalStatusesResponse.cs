namespace Pineu.Application.MainDomain.Patient.Queries.DTOs {
    public sealed record GetAllMentalStatusesForPatientResponse(
        DateOnly Date, IList<MentalStatusEnum> Value);
}
