using Pineu.Application.MainDomain.SleepStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.SleepStatuses.Queries {
    public sealed record GetAllSleepStatusesQuery(DateTime? From, DateTime? To, int? Page, int? PageSize, Guid UserId)
        : IQuery<PagedResponse<IEnumerable<GetAllSleepStatusesResponse>>>;
}
