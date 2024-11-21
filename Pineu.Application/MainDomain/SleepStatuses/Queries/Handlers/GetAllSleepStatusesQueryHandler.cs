using Pineu.Application.MainDomain.Seizures.Queries;
using Pineu.Application.MainDomain.SleepStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.SleepStatuses.Queries.Handlers {
    internal class GetAllSleepStatusesQueryHandler(ISleepStatusRepository repository, ISender sender)
        : IQueryHandler<GetAllSleepStatusesQuery, PagedResponse<IEnumerable<GetAllSleepStatusesResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetAllSleepStatusesResponse>>>> Handle(GetAllSleepStatusesQuery request, CancellationToken cancellationToken) {
            var sleepStatuses = await repository.GetAllAsync(request.From, request.To, request.Page, request.PageSize, request.UserId,
                cancellationToken);
            var seizures = await sender.Send(new GetAllSeizuresQuery(request.UserId, request.From, request.To, request.Page, request.PageSize),
                cancellationToken);

            var res = sleepStatuses.List.Select(ms => new GetAllSleepStatusesResponse(
                ms.Date,
                ms.Value,
                seizures.Value.List.Any(s => DateOnly.FromDateTime(s.SeizureDateTime) == ms.Date)));
            return new PagedResponse<IEnumerable<GetAllSleepStatusesResponse>>(res, sleepStatuses.Count);
        }
    }
}
