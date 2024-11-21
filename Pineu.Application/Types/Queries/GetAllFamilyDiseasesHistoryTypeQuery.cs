using Pineu.Application.MainDomain.DefaultIngredients.Queries.DTOs;
using Pineu.Application.Types.Queries.DTOs;
using Pineu.Domain.Repositories.Types;

namespace Pineu.Application.Types.Queries;
public sealed record GetAllFamilyDiseasesHistoryTypeQuery(string? Search, IEnumerable<short>? Ids) : IQuery<IEnumerable<GetTypeResponse>>;

internal class GetAllFamilyDiseasesHistoryTypeQueryHandler(IFamilyDiseasesHistoryTypeRepository repository)
    : IQueryHandler<GetAllFamilyDiseasesHistoryTypeQuery, IEnumerable<GetTypeResponse>> {
    public async Task<Result<IEnumerable<GetTypeResponse>>> Handle(GetAllFamilyDiseasesHistoryTypeQuery request, CancellationToken cancellationToken) {
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