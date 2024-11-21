using Pineu.Application.MainDomain.MentalStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.MentalStatuses.Queries {
    public sealed record GetMentalStatusByUserIdAndDateQuery(Guid UserId, DateTime? Date) : IQuery<GetMentalStatusResponse>;
}
