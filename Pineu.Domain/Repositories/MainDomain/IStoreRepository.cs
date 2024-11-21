namespace Pineu.Domain.Repositories.MainDomain;
public interface IStoreRepository {
    Task RemoveAsync(Store store, CancellationToken cancellationToken = default);
    Task UpdateAsync(Store store, CancellationToken cancellationToken = default);
    Task AddAsync(Store store, CancellationToken cancellationToken = default);
    Task<Store?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<PagedResponse<IEnumerable<Store>>> GetAllAsync(string? search, int? page, int? pageSize,
        CancellationToken cancellationToken = default);
}
