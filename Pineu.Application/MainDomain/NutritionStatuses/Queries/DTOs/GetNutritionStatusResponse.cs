namespace Pineu.Application.MainDomain.NutritionStatuses.Queries.DTOs {
    public sealed record GetNutritionStatusResponse(
        IEnumerable<DefaultIngredientObject> DefaultIngredients,
        IEnumerable<UserIngredientObject> UserIngredients);

    public sealed record DefaultIngredientObject(string Id, Label Label, IngredientCategory Type);
    public sealed record Label(string Fa, string En);
    public sealed record UserIngredientObject(string Id, string Name, IngredientCategory Type);
}
