using Pineu.Application.SystemFiles.Commands;

namespace Pineu.Application.MainDomain.Banners.Commands.Handlers;
internal class RemoveBannerCommandHandler(IBannerRepository repository, ISender sender) : ICommandHandler<RemoveBannerCommand> {
    public async Task<Result> Handle(RemoveBannerCommand request, CancellationToken cancellationToken) {
        var banner = await repository.GetAsync(request.Id, cancellationToken);
        if (banner == null) return Result.Failure(DomainErrors.Banner.BannerNotFound);

        await repository.RemoveAsync(banner, cancellationToken);
        await sender.Send(new RemoveSystemFileCommand(banner.ImageId), cancellationToken);
        return Result.Success();
    }
}
