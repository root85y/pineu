using Pineu.Application.MainDomain.UserIngredients.Queries.DTOs;

namespace Pineu.Application.MainDomain.UserIngredients.Queries {
    public sealed record GetAllUserIngredientsQuery(Guid UserId, string? Search, IEnumerable<IngredientCategory>? Category) 
        : IQuery<IEnumerable<GetUserIngredientResponse>>;
}
