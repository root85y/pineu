namespace Pineu.Domain.Repositories.MainDomain {
    public interface IUserIngredientRepository {
        Task UpdateAsync(UserIngredient userIngredient, CancellationToken cancellationToken = default);
        Task AddAsync(UserIngredient userIngredient, CancellationToken cancellationToken = default);
        Task<IEnumerable<UserIngredient>> GetAllAsync(Guid userId, string? search, IEnumerable<IngredientCategory>? category,
            IEnumerable<Guid>? ids, CancellationToken cancellationToken = default);
        Task<UserIngredient?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
