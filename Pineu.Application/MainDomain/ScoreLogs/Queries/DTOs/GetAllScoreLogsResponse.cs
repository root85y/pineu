namespace Pineu.Application.MainDomain.ScoreLogs.Queries.DTOs {
    public sealed record GetAllScoreLogsResponse(int Change, ScoreAction Action, string? Title, DateTime DateTime);
}
