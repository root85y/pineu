using Pineu.Persistence.Specifications.MainDomain.Discounts;

namespace Pineu.Persistence.Repositories.MainDomain {
    public class DiscountRepository(IRepository<Discount, Guid> repository) : IDiscountRepository {
        public async Task AddAsync(Discount discount, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(discount, cancellationToken);

        public async Task<PagedResponse<IEnumerable<Discount>>> GetAllAsync(string? search, int? page, int? pageSize, Guid? storeId, Guid? userId,
            CancellationToken cancellationToken = default) {
            var specification = new GetAllDiscountsSpecification(search, storeId, userId);
            var count = await repository.CountAsync(specification, cancellationToken);
            if (page.HasValue && pageSize.HasValue)
                specification.ToPaged(page.Value, pageSize.Value);

            return new PagedResponse<IEnumerable<Discount>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<Discount?> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
            await repository.FirstOrDefaultAsync(new GetDiscountByIdSpecification(id), cancellationToken);

        public async Task RemoveAsync(Discount discount, CancellationToken cancellationToken = default) =>
            await repository.DeleteAsync(discount, cancellationToken);

        public async Task UpdateAsync(Discount discount, CancellationToken cancellationToken = default) =>
            await repository.UpdateAsync(discount, cancellationToken);
    }
}
