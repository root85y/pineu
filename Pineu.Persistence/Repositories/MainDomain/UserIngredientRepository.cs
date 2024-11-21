using Pineu.Persistence.Specifications.MainDomain.UserIngredients;

namespace Pineu.Persistence.Repositories.MainDomain {
    internal class UserIngredientRepository(IRepository<UserIngredient, Guid> repository) : IUserIngredientRepository {
        public async Task AddAsync(UserIngredient userIngredient, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(userIngredient, cancellationToken);

        public async Task<IEnumerable<UserIngredient>> GetAllAsync(Guid userId, string? search, IEnumerable<IngredientCategory>? category,
            IEnumerable<Guid>? ids, CancellationToken cancellationToken = default) =>
            await repository.ListAsync(new GetAllUserIngredientsByUserIdSpecification(userId, search, category, ids), cancellationToken);

        public async Task<UserIngredient?> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
            await repository.GetByIdAsync(id, cancellationToken);

        public async Task UpdateAsync(UserIngredient userIngredient, CancellationToken cancellationToken = default) =>
            await repository.UpdateAsync(userIngredient, cancellationToken);
    }
}
