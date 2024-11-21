using Pineu.Application.MainDomain.MentalStatuses.Queries.DTOs;
using Pineu.Application.MainDomain.Patient.Queries.DTOs;

namespace Pineu.Application.MainDomain.MentalStatuses.Queries {
    public sealed record GetAllMentalStatusesQuery(DateTime? From, DateTime? To, int? Page, int? PageSize, Guid UserId)
        : IQuery<PagedResponse<IEnumerable<GetAllMentalStatusesResponse>>>;
}
