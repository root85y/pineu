namespace Pineu.API.DTOs.MainDomain.MentalStatuses {
    public sealed record UpsertMentalStatusRequest(List<MentalStatusEnum> Values, DateTime Date);
}
