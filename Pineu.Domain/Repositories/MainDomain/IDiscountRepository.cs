namespace Pineu.Domain.Repositories.MainDomain;

public interface IDiscountRepository {
    Task RemoveAsync(Discount discount, CancellationToken cancellationToken = default);
    Task UpdateAsync(Discount discount, CancellationToken cancellationToken = default);
    Task AddAsync(Discount discount, CancellationToken cancellationToken = default);
    Task<Discount?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<PagedResponse<IEnumerable<Discount>>> GetAllAsync(string? search, int? page, int? pageSize, Guid? storeId, Guid? userId,
        CancellationToken cancellationToken = default);
}
