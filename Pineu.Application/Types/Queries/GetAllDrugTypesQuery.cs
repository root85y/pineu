using Pineu.Application.MainDomain.DefaultIngredients.Queries.DTOs;
using Pineu.Application.Types.Queries.DTOs;
using Pineu.Domain.Repositories.Types;

namespace Pineu.Application.Types.Queries;

public sealed record GetAllDrugTypesQuery(string? Search, IEnumerable<short>? Ids) : IQuery<IEnumerable<GetTypeResponse>>;

internal class GetAllDrugTypesQueryHandler(IDrugTypeRepository repository)
    : IQueryHandler<GetAllDrugTypesQuery, IEnumerable<GetTypeResponse>> {
    public async Task<Result<IEnumerable<GetTypeResponse>>> Handle(GetAllDrugTypesQuery request, CancellationToken cancellationToken) {
        var types = await repository.GetAllAsync(request.Ids, request.Search, cancellationToken);
        var res = types.Select(t =>
            new GetTypeResponse(
                t.Id,
                new LanguageLabel(t.FarsiName, t.EnglishName)
            )
        ).ToList();
        return res;
    }
}