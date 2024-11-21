using Pineu.Application.MainDomain.Seizures.Queries.DTOs;

namespace Pineu.Application.MainDomain.Seizures.Queries.Handlers {
    internal class GetSeizuresChartHandler(ISeizureRepository repository)
        : IQueryHandler<GetSeizuresChartQuery, PagedResponse<IEnumerable<GetSeizuresChartResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetSeizuresChartResponse>>>> Handle(GetSeizuresChartQuery request, CancellationToken cancellationToken) {
            var seizures = await repository.GetAllAsync(request.From, request.To, null, null, request.UserId, cancellationToken);

            var res = seizures.List.GroupBy(s => s.SeizureDateTime.Date).Select(s => new GetSeizuresChartResponse(
                s.Key,
                seizures.List.Count(sz => sz.SeizureDateTime.Date == s.Key.Date),
                seizures.List.Where(sz => sz.SeizureDateTime.Date == s.Key.Date && sz.SeizureDuration != null)
                    .Average(sz => sz.SeizureDuration) ?? 0
                )
            ).OrderBy(s => s.Date);
            return new PagedResponse<IEnumerable<GetSeizuresChartResponse>>(res, seizures.Count);
        }
    }
}
