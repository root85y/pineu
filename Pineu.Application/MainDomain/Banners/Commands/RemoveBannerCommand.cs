namespace Pineu.Application.MainDomain.Banners.Commands;
public sealed record RemoveBannerCommand(Guid Id) : ICommand;
