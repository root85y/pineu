using Pineu.Application.MainDomain.SleepStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.SleepStatuses.Queries {
    public sealed record GetSleepStatusByUserIdQuery(Guid UserId, DateTime? Date) : IQuery<GetSleepStatusResponse>;
}
