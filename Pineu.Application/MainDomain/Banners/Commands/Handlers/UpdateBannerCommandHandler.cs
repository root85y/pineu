namespace Pineu.Application.MainDomain.Banners.Commands.Handlers;
internal class UpdateBannerCommandHandler(IBannerRepository repository, ISender sender) : ICommandHandler<UpdateBannerCommand> {
    public async Task<Result> Handle(UpdateBannerCommand request, CancellationToken cancellationToken) {
        var banner = await repository.GetAsync(request.Id, cancellationToken);
        if (banner == null) return Result.Failure(DomainErrors.Banner.BannerNotFound);

        if (request.ImageId != banner.ImageId) {
            var res = await sender.Send(new GetFileUriWithIdQuery(request.ImageId), cancellationToken);
            if (res.IsFailure) return Result.Failure(res.Error);
        }
        banner.Update(request.Title, request.Link, request.ImageId);
        await repository.UpdateAsync(banner, cancellationToken);

        return Result.Success();
    }
}
