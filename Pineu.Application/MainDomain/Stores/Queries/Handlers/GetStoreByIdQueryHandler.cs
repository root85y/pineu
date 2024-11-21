using Pineu.Application.MainDomain.Stores.Queries.DTOs;

namespace Pineu.Application.MainDomain.Stores.Queries.Handlers {
    internal class GetStoreByIdQueryHandler(IStoreRepository repository) : IQueryHandler<GetStoreByIdQuery, GetStoreResponse> {
        public async Task<Result<GetStoreResponse>> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken) {
            var store = await repository.GetAsync(request.Id, cancellationToken);
            if (store == null) return Result.Failure<GetStoreResponse>(DomainErrors.Store.StoreNotFound);

            return new GetStoreResponse(store.Title, store.ImageId, store.Address, store.PhoneNumber);
        }
    }
}
