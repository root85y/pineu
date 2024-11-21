
namespace Pineu.Application.MainDomain.Banners.Commands.Handlers;

internal class AddBannerCommandHandler(ISender sender, IBannerRepository repository) : ICommandHandler<AddBannerCommand, Guid> {
    public async Task<Result<Guid>> Handle(AddBannerCommand request, CancellationToken cancellationToken) {
        var image = await sender.Send(new GetFileUriWithIdQuery(request.ImageId), cancellationToken);
        if (image.IsFailure) return Result.Failure<Guid>(image.Error);

        var banner = Banner.Create(Guid.NewGuid(), request.Title, request.Link, request.ImageId);
        await repository.AddAsync(banner, cancellationToken);

        return banner.Id;
    }
}
