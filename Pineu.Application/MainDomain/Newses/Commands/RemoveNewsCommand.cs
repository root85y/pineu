namespace Pineu.Application.MainDomain.Newses.Commands {
    public sealed record RemoveNewsCommand(Guid Id) : ICommand;
}
