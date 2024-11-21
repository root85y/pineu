using Pineu.Application.MainDomain.Seizures.Queries;
using Pineu.Application.MainDomain.SleepStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.SleepStatuses.Queries.Handlers {
    internal class GetSleepStatusesChartQueryHandler(ISleepStatusRepository repository, ISender sender)
        : IQueryHandler<GetSleepStatusesChartQuery, PagedResponse<IEnumerable<GetSleepStatusChartResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetSleepStatusChartResponse>>>> Handle(GetSleepStatusesChartQuery request, CancellationToken cancellationToken) {
            var sleepStatuses = await repository.GetAllAsync(request.From, request.To, null, null, request.UserId, cancellationToken);
            var seizures = await sender.Send(new GetAllSeizuresQuery(request.UserId, request.From, request.To, null, null), cancellationToken);

            var res = sleepStatuses.List.Select(ss => new GetSleepStatusChartResponse(
                ss.Date.ToDateTime(TimeOnly.MinValue),
                ss.Value,
                seizures.Value.List.Any(s => DateOnly.FromDateTime(s.SeizureDateTime) == ss.Date))
            );

            return new PagedResponse<IEnumerable<GetSleepStatusChartResponse>>(res, sleepStatuses.Count);
        }
    }
}
