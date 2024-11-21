namespace Pineu.Application.MainDomain.Profiles.Commands {
    public sealed record UpdateProfileScoreCommand(ScoreAction Action, Guid UserId, Guid? DiscountId) : ICommand;
}
