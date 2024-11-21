namespace Pineu.Application.MainDomain.MentalStatuses.Commands {
    public sealed record UpsertMentalStatusCommand(Guid UserId, List<MentalStatusEnum> Value, DateTime Date) : ICommand;
}
