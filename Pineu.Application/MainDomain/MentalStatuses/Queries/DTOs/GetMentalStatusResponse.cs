namespace Pineu.Application.MainDomain.MentalStatuses.Queries.DTOs {
    public sealed record GetMentalStatusResponse(IEnumerable<MentalStatusEnum> Value);
}
