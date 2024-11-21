using Pineu.Persistence.Specifications.MainDomain.DefaultIngredients;

namespace Pineu.Persistence.Repositories.MainDomain;
internal class DefaultIngredientRepository(IRepository<DefaultIngredient, int> repository) : IDefaultIngredientRepository {
    public async Task<IEnumerable<DefaultIngredient>> GetAllAsync(string? search, IEnumerable<IngredientCategory>? category, 
        IEnumerable<int>? ids, CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllDefaultIngredientsSpecification(search, category, ids), cancellationToken);
}