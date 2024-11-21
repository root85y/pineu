using Pineu.Application.MainDomain.WorkoutStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.WorkoutStatuses.Queries {
    public sealed record GetWorkoutStatusesChartQuery(Guid UserId, DateTime? From, DateTime? To)
        : IQuery<PagedResponse<IEnumerable<GetWorkoutStatusChartResponse>>>;
}
