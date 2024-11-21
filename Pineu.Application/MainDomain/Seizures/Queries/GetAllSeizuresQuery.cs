using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.Seizures.Queries.DTOs;

namespace Pineu.Application.MainDomain.Seizures.Queries {
    public sealed record GetAllSeizuresQuery(Guid UserId, DateTime? From, DateTime? To, int? Page, int? PageSize)
        : IQuery<PagedResponse<IEnumerable<GetAllSeizuresResponse>>>;
}
