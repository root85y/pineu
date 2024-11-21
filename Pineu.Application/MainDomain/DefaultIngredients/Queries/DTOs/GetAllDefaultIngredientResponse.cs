namespace Pineu.Application.MainDomain.DefaultIngredients.Queries.DTOs;
public sealed record GetAllDefaultIngredientResponse(string Id, IngredientCategory Type, LanguageLabel Label);
public sealed record LanguageLabel(string Fa, string En);
