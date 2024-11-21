using Pineu.Application.MainDomain.DefaultIngredients.Queries.DTOs;

namespace Pineu.Application.MainDomain.DefaultIngredients.Queries.Handlers;
internal class GetAllDefaultIngredientQueryHandler(IDefaultIngredientRepository repository) : IQueryHandler<GetAllDefaultIngredientQuery, IEnumerable<GetAllDefaultIngredientResponse>> {
    public async Task<Result<IEnumerable<GetAllDefaultIngredientResponse>>> Handle(GetAllDefaultIngredientQuery request, CancellationToken cancellationToken) {
        var ingredients = await repository.GetAllAsync(request.Search, request.Category, null, cancellationToken);

        var res = ingredients.Select(d => new GetAllDefaultIngredientResponse(
            d.Id.ToString(),
            d.Category,
            new LanguageLabel(d.FarsiLabel, d.EnglishLabel)
        ));
        return res.ToList();
    }
}