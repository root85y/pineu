namespace Pineu.Domain.Repositories.MainDomain;
public interface IBannerRepository {
    Task RemoveAsync(Banner banner, CancellationToken cancellationToken = default);
    Task UpdateAsync(Banner banner, CancellationToken cancellationToken = default);
    Task AddAsync(Banner banner, CancellationToken cancellationToken = default);
    Task<Banner?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<PagedResponse<IEnumerable<Banner>>> GetAllAsync(string? search, int? page, int? pageSize,
        CancellationToken cancellationToken = default);
}
