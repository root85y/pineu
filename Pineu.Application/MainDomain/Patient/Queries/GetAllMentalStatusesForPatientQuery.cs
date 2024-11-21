using Pineu.Application.MainDomain.MentalStatuses.Queries.DTOs;
using Pineu.Application.MainDomain.Patient.Queries.DTOs;

namespace Pineu.Application.MainDomain.Patient.Queries {
    public sealed record GetAllMentalStatusesForPatientQuery(DateTime? From, DateTime? To, Guid UserId)
        : IQuery<PagedResponse<IEnumerable<GetAllMentalStatusesForPatientResponse>>>;
}
