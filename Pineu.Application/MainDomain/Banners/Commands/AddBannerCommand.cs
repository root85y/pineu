namespace Pineu.Application.MainDomain.Banners.Commands;
public sealed record AddBannerCommand(string Title, string Link, Guid ImageId) : ICommand<Guid>;
