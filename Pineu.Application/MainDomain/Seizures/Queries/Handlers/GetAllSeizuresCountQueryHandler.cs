using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.Seizures.Queries.DTOs;

namespace Pineu.Application.MainDomain.Seizures.Queries.Handlers {
    internal class GetAllSeizuresCountQueryHandler(ISeizureRepository repository) : IQueryHandler<GetAllSeizuresCountQuery, PagedResponse<IEnumerable<GetAllSeizuresResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetAllSeizuresResponse>>>> Handle(GetAllSeizuresCountQuery request, CancellationToken cancellationToken) {
            var seizures = await repository.GetAllCountAsync(request.From, request.To, request.UserId,request.PatientData, cancellationToken);

            var res = seizures.List.Select(s => new GetAllSeizuresResponse(
                s.SeizureDateTime,
                s.SeizureDuration
                )
            );
            return new PagedResponse<IEnumerable<GetAllSeizuresResponse>>(res, seizures.Count);
        }
    }
}
