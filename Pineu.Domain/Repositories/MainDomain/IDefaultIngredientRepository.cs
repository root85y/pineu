namespace Pineu.Domain.Repositories.MainDomain;

public interface IDefaultIngredientRepository {
    Task<IEnumerable<DefaultIngredient>> GetAllAsync(string? search, IEnumerable<IngredientCategory>? category, 
        IEnumerable<int>? ids, CancellationToken cancellationToken = default);
}
