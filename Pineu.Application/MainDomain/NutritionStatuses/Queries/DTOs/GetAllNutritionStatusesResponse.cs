namespace Pineu.Application.MainDomain.NutritionStatuses.Queries.DTOs {
    public sealed record GetAllNutritionStatusesResponse(DateOnly Date, IEnumerable<DefaultIngredientObject> DefaultIngredients,
        IEnumerable<UserIngredientObject> UserIngredients, bool HasSeizureHappened);
}
