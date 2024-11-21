using Pineu.Application.MainDomain.MentalStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.MentalStatuses.Queries {
    public sealed record GetMentalStatusesChartQuery(DateTime? From, DateTime? To, Guid UserId) :
        IQuery<GetMentalStatusChartResponse>;
}
