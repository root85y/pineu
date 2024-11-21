namespace Pineu.API.DTOs.MainDomain.NutritionStatuses {
    public sealed record UpsertNutritionStatusRequest(
        IEnumerable<int> DefaultIngredients,
        IEnumerable<Guid> UserIngredients,
        DateTime Date);
}
