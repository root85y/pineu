using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.Seizures.Queries.DTOs;

namespace Pineu.Application.MainDomain.Seizures.Queries.Handlers {
    internal class GetAllSeizuresQueryHandler(ISeizureRepository repository) : IQueryHandler<GetAllSeizuresQuery, PagedResponse<IEnumerable<GetAllSeizuresResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetAllSeizuresResponse>>>> Handle(GetAllSeizuresQuery request, CancellationToken cancellationToken) {
            var seizures = await repository.GetAllAsync(request.From, request.To, request.Page, request.PageSize, request.UserId, cancellationToken);

            var res = seizures.List.Select(s => new GetAllSeizuresResponse(
                s.SeizureDateTime,
                s.SeizureDuration
                )
            );
            return new PagedResponse<IEnumerable<GetAllSeizuresResponse>>(res, seizures.Count);
        }
    }
}
