namespace Pineu.Application.MainDomain.UserIngredients.Queries.DTOs {
    public sealed record GetUserIngredientResponse(Guid Id, string Name, IngredientCategory Type);
}
