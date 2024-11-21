using Pineu.Domain.Entities.Types;
using Pineu.Domain.Repositories.Types;
using Pineu.Persistence.Specifications.Types;

namespace Pineu.Persistence.Repositories.Types;

internal class FamilyDiseasesHistoryTypeRepository (IRepository<FamilyDiseasesHistoryType, short> repository) : IFamilyDiseasesHistoryTypeRepository {
    public async Task<IEnumerable<FamilyDiseasesHistoryType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllFamilyDiseasesHistoryTypeSpecification(ids, search), cancellationToken);
}