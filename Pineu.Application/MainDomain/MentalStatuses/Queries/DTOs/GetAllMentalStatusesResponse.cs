namespace Pineu.Application.MainDomain.MentalStatuses.Queries.DTOs {
    public sealed record GetAllMentalStatusesResponse(DateOnly Date, IList<MentalStatusEnum> Value, bool HasSeizureHappened);
}
