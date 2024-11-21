namespace Pineu.Persistence.Specifications.MainDomain.UserIngredients {
    internal sealed class GetAllUserIngredientsByUserIdSpecification : Specification<UserIngredient> {
        public GetAllUserIngredientsByUserIdSpecification(Guid userId, string? search, IEnumerable<IngredientCategory>? category,
            IEnumerable<Guid>? ids) {
            Query.Where(di => ids.Contains(di.Id), ids != null)
                .Where(di => di.Name.Contains(search), !string.IsNullOrWhiteSpace(search))
                .Where(di => category.Contains(di.Category), category != null && category.Any())
                .Where(ui => ui.UserId == userId);
        }
    }
}
