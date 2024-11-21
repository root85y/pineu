namespace Pineu.Application.MainDomain.Newses.Commands {
    public sealed record UpdateNewsCommand(Guid Id, string Title, string Body, string Link, Guid ImageId) : ICommand;
}
