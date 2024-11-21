namespace Pineu.Application.MainDomain.Banners.Commands;
public sealed record UpdateBannerCommand(Guid Id, string Title, string Link, Guid ImageId) : ICommand;
