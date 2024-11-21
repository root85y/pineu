using Pineu.Application.MainDomain.SleepStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.SleepStatuses.Queries {
    public sealed record GetSleepStatusesChartQuery(Guid UserId, DateTime? From, DateTime? To)
        : IQuery<PagedResponse<IEnumerable<GetSleepStatusChartResponse>>>;
}
