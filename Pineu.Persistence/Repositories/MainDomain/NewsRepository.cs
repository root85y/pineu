using Pineu.Persistence.Specifications.MainDomain.Newses;

namespace Pineu.Persistence.Repositories.MainDomain {
    internal class NewsRepository(IRepository<News, Guid> repository) : INewsRepository {
        public async Task AddAsync(News news, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(news, cancellationToken);

        public async Task<PagedResponse<IEnumerable<News>>> GetAllAsync(string? search, int? page, int? pageSize, CancellationToken cancellationToken = default) {
            var specification = new GetAllNewsSpecification(search);
            var count = await repository.CountAsync(specification, cancellationToken);

            if (page.HasValue && pageSize.HasValue)
                specification.ToPaged(page.Value, pageSize.Value);

            return new PagedResponse<IEnumerable<News>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<News?> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
            await repository.GetByIdAsync(id, cancellationToken);

        public async Task RemoveAsync(News news, CancellationToken cancellationToken = default) =>
            await repository.DeleteAsync(news, cancellationToken);

        public async Task UpdateAsync(News news, CancellationToken cancellationToken = default) =>
            await repository.UpdateAsync(news, cancellationToken);
    }
}
