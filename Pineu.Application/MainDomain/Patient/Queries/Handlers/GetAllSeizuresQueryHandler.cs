using Pineu.Application.MainDomain.Patient.Queries;
using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.Seizures.Queries.DTOs;

namespace Pineu.Application.MainDomain.Seizures.Queries.Handlers {
    internal class GetAllSeizuresForPatientQueryHandler(ISeizureRepository repository) : IQueryHandler<GetAllSeizuresForPatientQuery, PagedResponse<IEnumerable<GetAllSeizuresForPatientResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetAllSeizuresForPatientResponse>>>> Handle(GetAllSeizuresForPatientQuery request, CancellationToken cancellationToken) {
            var seizures = await repository.GetAllForPatientAsync(request.From, request.To, request.UserId, cancellationToken);

            var res = seizures.List.Select(s => new GetAllSeizuresForPatientResponse(
                s.SeizureDateTime,
                s.SeizureDuration
                )
            );
            return new PagedResponse<IEnumerable<GetAllSeizuresForPatientResponse>>(res, seizures.Count);
        }
    }
}
