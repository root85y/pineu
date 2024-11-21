using Pineu.Application.MainDomain.DefaultIngredients.Queries.DTOs;

namespace Pineu.Application.Types.Queries.DTOs;

public sealed record GetTypeResponse(short Id, LanguageLabel Label);