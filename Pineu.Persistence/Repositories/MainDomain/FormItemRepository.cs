using Pineu.Persistence.Specifications.MainDomain.FormItems;
using Shared.Constants.Enums;

namespace Pineu.Persistence.Repositories.MainDomain {
    internal class FormItemRepository(IRepository<FormItem, Guid> repository) : IFormItemRepository {
        public async Task AddAsync(FormItem formItem, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(formItem, cancellationToken);

        public async Task<PagedResponse<IEnumerable<FormItem>>> GetAllAsync(string? search, int? page, int? pageSize,
            FormName? formName, FormItemTemplate? template, CancellationToken cancellationToken = default) {
            var specification = new GetAllFormItemsSpecification(search, formName, template);
            var count = await repository.CountAsync(specification, cancellationToken);

            if (page.HasValue && pageSize.HasValue)
                specification.ToPaged(page.Value, pageSize.Value);

            return new PagedResponse<IEnumerable<FormItem>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<FormItem?> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
            await repository.GetByIdAsync(id, cancellationToken);

        public async Task RemoveAsync(FormItem formItem, CancellationToken cancellationToken = default) =>
            await repository.DeleteAsync(formItem, cancellationToken);

        public async Task UpdateAsync(FormItem formItem, CancellationToken cancellationToken = default) =>
            await repository.UpdateAsync(formItem, cancellationToken);
    }
}
