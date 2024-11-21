using Pineu.Application.MainDomain.ScoreLogs.Queries.DTOs;

namespace Pineu.Application.MainDomain.ScoreLogs.Queries {
    public sealed record GetUsersScoreSummeryQuery(Guid UserId) : IQuery<GetUsersScoreSummeryResponse>;
}
