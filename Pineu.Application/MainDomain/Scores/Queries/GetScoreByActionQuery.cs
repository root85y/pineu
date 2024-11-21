using Pineu.Application.MainDomain.Scores.Queries.DTOs;

namespace Pineu.Application.MainDomain.Scores.Queries {
    public sealed record GetScoreByActionQuery(ScoreAction Action) : IQuery<GetScoreResponse>;
}
