namespace Pineu.Application.MainDomain.Scores.Queries.DTOs {
    public sealed record GetScoreResponse(ScoreAction Action, int ScoreCount);
}
