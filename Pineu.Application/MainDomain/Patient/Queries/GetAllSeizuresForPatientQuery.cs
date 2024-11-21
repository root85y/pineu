using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.Seizures.Queries.DTOs;

namespace Pineu.Application.MainDomain.Patient.Queries {
    public sealed record GetAllSeizuresForPatientQuery(DateTime? From, DateTime? To, Guid UserId)
        : IQuery<PagedResponse<IEnumerable<GetAllSeizuresForPatientResponse>>>;
}
