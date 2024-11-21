using Pineu.Persistence.Specifications.MainDomain.Banners;

namespace Pineu.Persistence.Repositories.MainDomain {
    internal class BannerRepository(IRepository<Banner, Guid> repository) : IBannerRepository {
        public async Task AddAsync(Banner banner, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(banner, cancellationToken);

        public async Task<PagedResponse<IEnumerable<Banner>>> GetAllAsync(string? search, int? page, int? pageSize, CancellationToken cancellationToken = default) {
            var specification = new GetAllBannersSpecification(search);
            var count = await repository.CountAsync(specification, cancellationToken);

            if (page.HasValue && pageSize.HasValue)
                specification.ToPaged(page.Value, pageSize.Value);

            return new PagedResponse<IEnumerable<Banner>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<Banner?> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
            await repository.GetByIdAsync(id, cancellationToken);

        public async Task RemoveAsync(Banner banner, CancellationToken cancellationToken = default) =>
            await repository.DeleteAsync(banner, cancellationToken);

        public async Task UpdateAsync(Banner banner, CancellationToken cancellationToken = default) =>
            await repository.UpdateAsync(banner, cancellationToken);
    }
}
