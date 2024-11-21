using Pineu.Application.MainDomain.WorkoutStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.WorkoutStatuses.Queries {
    public sealed record GetAllWorkoutStatusesQuery(Guid UserId, DateTime? From, DateTime? To, int? Page, int? PageSize)
        : IQuery<PagedResponse<IEnumerable<GetAllWorkoutStatusesResponse>>>;
}
