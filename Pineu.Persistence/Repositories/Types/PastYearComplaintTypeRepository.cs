using Pineu.Domain.Entities.Types;
using Pineu.Domain.Repositories.Types;
using Pineu.Persistence.Specifications.Types;

namespace Pineu.Persistence.Repositories.Types;

internal class PastYearComplaintTypeRepository (IRepository<PastYearComplaintType, short> repository) : IPastYearComplaintTypeRepository {
    public async Task<IEnumerable<PastYearComplaintType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllPastYearComplaintTypeSpecification(ids, search), cancellationToken);
}