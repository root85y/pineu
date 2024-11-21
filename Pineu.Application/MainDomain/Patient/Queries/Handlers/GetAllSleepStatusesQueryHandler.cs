using Pineu.Application.MainDomain.Patient.Queries.DTOs;

namespace Pineu.Application.MainDomain.Patient.Queries.Handlers {
    internal class GetAllSleepStatusesForPatiantQueryHandler(ISleepStatusRepository repository)
        : IQueryHandler<GetAllSleepStatusesForPatiantQuery, PagedResponse<IEnumerable<GetAllSleepStatForPatientResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetAllSleepStatForPatientResponse>>>> Handle(GetAllSleepStatusesForPatiantQuery request, CancellationToken cancellationToken) {
            var sleepStatuses = await repository.GetAllForPatientAsync(
                request.From,
                request.To,
                request.UserId,
                cancellationToken);

            var res = sleepStatuses.List.Select(ms => new GetAllSleepStatForPatientResponse(
                ms.Date,
                ms.Value
                ));
            return new PagedResponse<IEnumerable<GetAllSleepStatForPatientResponse>>(res, sleepStatuses.Count);
        }
    }
}
