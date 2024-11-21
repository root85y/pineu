using Pineu.Application.MainDomain.ScoreLogs.Queries.DTOs;

namespace Pineu.Application.MainDomain.ScoreLogs.Queries {
    public sealed record GetAllScoreLogsQuery(DateTime? From, DateTime? To, int? Page, int? PageSize, Guid UserId, ScoreType? Type)
        : IQuery<PagedResponse<IEnumerable<GetAllScoreLogsResponse>>>;
}
