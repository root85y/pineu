namespace Pineu.Application.MainDomain.ScoreLogs.Commands {
    public sealed record AddScoreLogCommand(Guid UserId, int Change, int RemainingScore, ScoreAction Action, Guid? DiscountId) : ICommand;
}
