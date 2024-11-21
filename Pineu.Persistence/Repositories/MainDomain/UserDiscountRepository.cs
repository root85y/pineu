using Pineu.Persistence.Specifications.MainDomain.UserDiscounts;

namespace Pineu.Persistence.Repositories.MainDomain {
    public class UserDiscountRepository(IRepository<UserDiscount, Guid> repository) : IUserDiscountRepository {
        public async Task AddAsync(UserDiscount userDiscount, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(userDiscount, cancellationToken);

        public async Task<PagedResponse<IEnumerable<UserDiscount>>> GetAllAsync(int? page, int? pageSize, Guid? userId, CancellationToken cancellationToken = default) {
            var specification = new GetAllUserDiscountsSpecification(userId);
            var count = await repository.CountAsync(specification, cancellationToken);
            if (page.HasValue && pageSize.HasValue)
                specification.ToPaged(page.Value, pageSize.Value);

            return new PagedResponse<IEnumerable<UserDiscount>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<UserDiscount?> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
            await repository.GetByIdAsync(id, cancellationToken);

        public async Task RemoveAsync(UserDiscount userDiscount, CancellationToken cancellationToken = default) =>
            await repository.DeleteAsync(userDiscount, cancellationToken);
    }
}
