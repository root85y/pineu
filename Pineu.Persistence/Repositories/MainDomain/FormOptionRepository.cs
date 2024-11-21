using Pineu.Persistence.Specifications.MainDomain.FormOptions;

namespace Pineu.Persistence.Repositories.MainDomain {
    internal class FormOptionRepository(IRepository<FormOption, Guid> repository) : IFormOptionRepository {
        public async Task AddAsync(FormOption formOption, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(formOption, cancellationToken);

        public async Task<PagedResponse<IEnumerable<FormOption>>> GetAllAsync(string? search, int? page, int? pageSize, Guid? formItemId, CancellationToken cancellationToken = default) {
            var specification = new GetAllFormOptionsSpecification(search, formItemId);
            var count = await repository.CountAsync(specification, cancellationToken);

            if (page.HasValue && pageSize.HasValue)
                specification.ToPaged(page.Value, pageSize.Value);

            return new PagedResponse<IEnumerable<FormOption>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<FormOption?> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
            await repository.GetByIdAsync(id, cancellationToken);

        public async Task RemoveAsync(FormOption formOption, CancellationToken cancellationToken = default) =>
            await repository.DeleteAsync(formOption, cancellationToken);

        public async Task UpdateAsync(FormOption formOption, CancellationToken cancellationToken = default) =>
            await repository.UpdateAsync(formOption, cancellationToken);
    }
}
