namespace Pineu.Domain.Repositories.MainDomain;
public interface IFormOptionRepository {
    Task RemoveAsync(FormOption formOption, CancellationToken cancellationToken = default);
    Task UpdateAsync(FormOption formOption, CancellationToken cancellationToken = default);
    Task AddAsync(FormOption formOption, CancellationToken cancellationToken = default);
    Task<FormOption?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<PagedResponse<IEnumerable<FormOption>>> GetAllAsync(string? search, int? page, int? pageSize, Guid? formItemId,
        CancellationToken cancellationToken = default);
}
