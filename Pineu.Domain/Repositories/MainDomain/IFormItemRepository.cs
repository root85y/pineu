namespace Pineu.Domain.Repositories.MainDomain;
public interface IFormItemRepository {
    Task RemoveAsync(FormItem formItem, CancellationToken cancellationToken = default);
    Task UpdateAsync(FormItem formItem, CancellationToken cancellationToken = default);
    Task AddAsync(FormItem formItem, CancellationToken cancellationToken = default);
    Task<FormItem?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<PagedResponse<IEnumerable<FormItem>>> GetAllAsync(string? search, int? page, int? pageSize, FormName? formName,
        FormItemTemplate? template, CancellationToken cancellationToken = default);
}
