using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.Seizures.Queries.DTOs;

namespace Pineu.Application.MainDomain.Seizures.Queries {
    public sealed record GetAllSeizuresCountQuery(Guid UserId,Profile PatientData, DateTime? From, DateTime? To) : IQuery<PagedResponse<IEnumerable<GetAllSeizuresResponse>>>;
}
