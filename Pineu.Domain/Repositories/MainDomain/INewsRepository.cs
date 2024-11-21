namespace Pineu.Domain.Repositories.MainDomain;
public interface INewsRepository {
    Task RemoveAsync(News news, CancellationToken cancellationToken = default);
    Task UpdateAsync(News news, CancellationToken cancellationToken = default);
    Task AddAsync(News news, CancellationToken cancellationToken = default);
    Task<News?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<PagedResponse<IEnumerable<News>>> GetAllAsync(string? search, int? page, int? pageSize,
        CancellationToken cancellationToken = default);
}
