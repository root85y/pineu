using Pineu.Application.MainDomain.Banners.Queries.DTOs;

namespace Pineu.Application.MainDomain.Banners.Queries.Handlers;
internal class GetBannerByIdQueryHandler(IBannerRepository repository) : IQueryHandler<GetBannerByIdQuery, GetBannerResponse> {
    public async Task<Result<GetBannerResponse>> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken) {
        var banner = await repository.GetAsync(request.Id, cancellationToken);
        if (banner == null) return Result.Failure<GetBannerResponse>(DomainErrors.Banner.BannerNotFound);

        return new GetBannerResponse(banner.Id, banner.Title, banner.Link, banner.ImageId);
    }
}
