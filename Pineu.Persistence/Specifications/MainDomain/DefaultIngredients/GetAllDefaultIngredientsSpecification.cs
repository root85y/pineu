namespace Pineu.Persistence.Specifications.MainDomain.DefaultIngredients {
    internal class GetAllDefaultIngredientsSpecification : Specification<DefaultIngredient> {
        public GetAllDefaultIngredientsSpecification(string? search, IEnumerable<IngredientCategory>? category, IEnumerable<int>? ids) {
            Query.Where(di => ids.Contains(di.Id), ids != null)
                .Where(di => di.EnglishLabel.Contains(search) || di.FarsiLabel.Contains(search), !string.IsNullOrWhiteSpace(search))
                .Where(di => category.Contains(di.Category), category != null && category.Any())
                .OrderByDescending(di => di.CreatedAt);
        }
    }
}
