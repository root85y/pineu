using Pineu.Application.MainDomain.DefaultIngredients.Queries.DTOs;

namespace Pineu.Application.MainDomain.DefaultIngredients.Queries;
public sealed record GetAllDefaultIngredientQuery(string? Search, IEnumerable<IngredientCategory>? Category)
    : IQuery<IEnumerable<GetAllDefaultIngredientResponse>>;
