using Pineu.Application.MainDomain.Stores.Queries.DTOs;
using Pineu.Application.SystemFiles.Commands.DTOs;

namespace Pineu.Application.MainDomain.Stores.Queries.Handlers {
    internal class GetAllStoresQueryHandler(IStoreRepository repository, ISender sender)
        : IQueryHandler<GetAllStoresQuery, PagedResponse<IEnumerable<GetAllStoresResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetAllStoresResponse>>>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken) {
            var stores = await repository.GetAllAsync(request.Search, request.Page, request.PageSize, cancellationToken);

            var res = new List<GetAllStoresResponse>();
            foreach (var store in stores.List) {
                Result<SystemFileResponse> image = null;
                if (store.ImageId.HasValue)
                    image = await sender.Send(new GetFileUriWithIdQuery(store.ImageId.Value), cancellationToken);

                res.Add(new GetAllStoresResponse(store.Id, store.Title, store.Address, store.PhoneNumber,
                    image != null && image.IsSuccess ? image.Value.Url : "",
                    store.Discounts.Count != 0 ? store.Discounts.Max(d => d.OffPercentage) : null));
            }

            return new PagedResponse<IEnumerable<GetAllStoresResponse>>(res, stores.Count);
        }
    }
}
