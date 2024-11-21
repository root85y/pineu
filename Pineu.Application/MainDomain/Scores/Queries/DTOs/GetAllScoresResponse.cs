namespace Pineu.Application.MainDomain.Scores.Queries.DTOs {
    public sealed record GetAllScoresResponse(Guid Id, ScoreAction Action, int ScoreCount);
}
