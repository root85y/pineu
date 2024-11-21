using Pineu.Application.MainDomain.Banners.Queries.DTOs;

namespace Pineu.Application.MainDomain.Banners.Queries.Handlers;
internal class GetAllBannersQueryHandler(IBannerRepository repository, ISender sender)
    : IQueryHandler<GetAllBannersQuery, PagedResponse<IEnumerable<GetAllBannerResponse>>> {
    public async Task<Result<PagedResponse<IEnumerable<GetAllBannerResponse>>>> Handle(GetAllBannersQuery request, CancellationToken cancellationToken) {
        var banners = await repository.GetAllAsync(request.Search, request.Page, request.PageSize, cancellationToken);

        List<GetAllBannerResponse> result = [];
        foreach (var banner in banners.List) {
            var image = await sender.Send(new GetFileUriWithIdQuery(banner.ImageId), cancellationToken);
            result.Add(new GetAllBannerResponse(
                banner.Id,
                banner.Title,
                banner.Link,
                image.IsSuccess ? image.Value.Url : ""
                ));
        }
        return new PagedResponse<IEnumerable<GetAllBannerResponse>>(result, banners.Count);
    }
}
