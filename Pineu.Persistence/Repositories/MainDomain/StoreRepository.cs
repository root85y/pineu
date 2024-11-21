using Pineu.Persistence.Specifications.MainDomain.Stores;

namespace Pineu.Persistence.Repositories.MainDomain {
    public class StoreRepository(IRepository<Store, Guid> repository) : IStoreRepository {
        public async Task AddAsync(Store store, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(store, cancellationToken);

        public async Task<PagedResponse<IEnumerable<Store>>> GetAllAsync(string? search, int? page, int? pageSize, CancellationToken cancellationToken = default) {
            var specification = new GetAllStoresSpecification(search);
            var count = await repository.CountAsync(specification, cancellationToken);
            if (page.HasValue && pageSize.HasValue)
                specification.ToPaged(page.Value, pageSize.Value);

            return new PagedResponse<IEnumerable<Store>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<Store?> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
            await repository.GetByIdAsync(id, cancellationToken);

        public async Task RemoveAsync(Store store, CancellationToken cancellationToken = default) =>
            await repository.DeleteAsync(store, cancellationToken);

        public async Task UpdateAsync(Store store, CancellationToken cancellationToken = default) =>
            await repository.UpdateAsync(store, cancellationToken);
    }
}
