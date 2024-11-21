using Pineu.Domain.Entities.Types;

namespace Pineu.Domain.Repositories.Types;

public interface IFamilyDiseasesHistoryTypeRepository {
    Task<IEnumerable<FamilyDiseasesHistoryType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default);
}