namespace Pineu.Application.MainDomain.MentalStatuses.Queries.DTOs {
    public sealed record GetMentalStatusChartResponse(IEnumerable<MentalStatusEnum> MentalStatusList, IEnumerable<int> MentalStatusAmountList);
}
