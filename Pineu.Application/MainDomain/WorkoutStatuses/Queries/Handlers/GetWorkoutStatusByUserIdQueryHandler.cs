using Pineu.Application.MainDomain.WorkoutStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.WorkoutStatuses.Queries.Handlers {
    internal class GetWorkoutStatusByUserIdQueryHandler(IWorkoutStatusRepository repository) : IQueryHandler<GetWorkoutStatusByUserIdQuery, GetWorkoutStatusResponse> {
        public async Task<Result<GetWorkoutStatusResponse>> Handle(GetWorkoutStatusByUserIdQuery request, CancellationToken cancellationToken) {
            var workoutS = await repository.GetAsync(request.UserId, request.Date, cancellationToken);
            if (workoutS == null) return Result.Failure<GetWorkoutStatusResponse>(DomainErrors.WorkoutStatus.WorkoutStatusNotFound);

            return new GetWorkoutStatusResponse(workoutS.Value);
        }
    }
}
