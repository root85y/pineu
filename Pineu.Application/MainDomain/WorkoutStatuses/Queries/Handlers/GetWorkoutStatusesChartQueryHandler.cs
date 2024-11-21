using Pineu.Application.MainDomain.Seizures.Queries;
using Pineu.Application.MainDomain.WorkoutStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.WorkoutStatuses.Queries.Handlers {
    internal class GetWorkoutStatusesChartQueryHandler(IWorkoutStatusRepository repository, ISender sender)
        : IQueryHandler<GetWorkoutStatusesChartQuery, PagedResponse<IEnumerable<GetWorkoutStatusChartResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetWorkoutStatusChartResponse>>>> Handle(GetWorkoutStatusesChartQuery request, CancellationToken cancellationToken) {
            var workoutStatuses = await repository.GetAllAsync(request.From, request.To, null, null, request.UserId, cancellationToken);
            var seizures = await sender.Send(new GetAllSeizuresQuery(request.UserId, request.From, request.To, null, null), cancellationToken);

            var res = workoutStatuses.List.Select(ss => new GetWorkoutStatusChartResponse(
                ss.Date.ToDateTime(TimeOnly.MinValue),
                ss.Value,
                seizures.Value.List.Any(s => DateOnly.FromDateTime(s.SeizureDateTime) == ss.Date))
            );

            return new PagedResponse<IEnumerable<GetWorkoutStatusChartResponse>>(res, workoutStatuses.Count);
        }
    }
}
