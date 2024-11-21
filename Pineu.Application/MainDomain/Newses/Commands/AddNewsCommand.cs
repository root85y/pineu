namespace Pineu.Application.MainDomain.Newses.Commands {
    public sealed record AddNewsCommand(string Title, string Body, string Link, Guid ImageId) : ICommand<Guid>;
}
