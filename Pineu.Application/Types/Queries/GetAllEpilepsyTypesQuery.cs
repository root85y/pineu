using Pineu.Application.MainDomain.DefaultIngredients.Queries.DTOs;
using Pineu.Application.Types.Queries.DTOs;
using Pineu.Domain.Repositories.Types;

namespace Pineu.Application.Types.Queries;

public sealed record GetAllEpilepsyTypesQuery(string? Search, IEnumerable<short>? Ids) : IQuery<IEnumerable<GetTypeResponse>>;

internal class GetAllEpilepsyTypesQueryHandler(IEpilepsyTypeRepository repository)
    : IQueryHandler<GetAllEpilepsyTypesQuery, IEnumerable<GetTypeResponse>> {
    public async Task<Result<IEnumerable<GetTypeResponse>>> Handle(GetAllEpilepsyTypesQuery request, CancellationToken cancellationToken) {
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