using Pineu.Application.MainDomain.DefaultIngredients.Queries.DTOs;
using Pineu.Application.Types.Queries.DTOs;
using Pineu.Domain.Repositories.Types;

namespace Pineu.Application.Types.Queries;
public sealed record GetAllPastYearComplaintTypeQuery(string? Search, IEnumerable<short>? Ids) : IQuery<IEnumerable<GetTypeResponse>>;

internal class GetAllPastYearComplaintTypeQueryHandler(IPastYearComplaintTypeRepository repository)
    : IQueryHandler<GetAllPastYearComplaintTypeQuery, IEnumerable<GetTypeResponse>> {
    public async Task<Result<IEnumerable<GetTypeResponse>>> Handle(GetAllPastYearComplaintTypeQuery request, CancellationToken cancellationToken) {
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