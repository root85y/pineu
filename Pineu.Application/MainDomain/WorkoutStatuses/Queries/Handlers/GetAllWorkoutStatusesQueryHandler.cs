using Pineu.Application.MainDomain.Seizures.Queries;
using Pineu.Application.MainDomain.WorkoutStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.WorkoutStatuses.Queries.Handlers {
    internal class GetAllWorkoutStatusesQueryHandler(IWorkoutStatusRepository repository, ISender sender)
        : IQueryHandler<GetAllWorkoutStatusesQuery, PagedResponse<IEnumerable<GetAllWorkoutStatusesResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetAllWorkoutStatusesResponse>>>> Handle(GetAllWorkoutStatusesQuery request, CancellationToken cancellationToken) {
            var workoutStatuses = await repository.GetAllAsync(request.From, request.To, request.Page, request.PageSize, request.UserId,
                cancellationToken);
            var seizures = await sender.Send(new GetAllSeizuresQuery(request.UserId, request.From, request.To, request.Page, request.PageSize),
                cancellationToken);

            var res = workoutStatuses.List.Select(ms => new GetAllWorkoutStatusesResponse(
                ms.Date,
                ms.Value,
                seizures.Value.List.Any(s => DateOnly.FromDateTime(s.SeizureDateTime) == ms.Date)));
            return new PagedResponse<IEnumerable<GetAllWorkoutStatusesResponse>>(res, workoutStatuses.Count);
        }
    }
}
