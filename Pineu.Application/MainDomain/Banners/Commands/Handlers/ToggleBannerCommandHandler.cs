namespace Pineu.Application.MainDomain.Banners.Commands.Handlers;
internal class ToggleBannerCommandHandler(IBannerRepository repository) : ICommandHandler<ToggleBannerCommand> {
    public async Task<Result> Handle(ToggleBannerCommand request, CancellationToken cancellationToken) {
        var banner = await repository.GetAsync(request.Id, cancellationToken);
        if (banner == null) return Result.Failure(DomainErrors.Banner.BannerNotFound);

        banner.ToggleActivation();
        await repository.UpdateAsync(banner, cancellationToken);

        return Result.Success();
    }
}
