using Pineu.Application.MainDomain.WorkoutStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.WorkoutStatuses.Queries {
    public sealed record GetWorkoutStatusByUserIdQuery(Guid UserId, DateTime? Date) : IQuery<GetWorkoutStatusResponse>;
}
