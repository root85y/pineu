using Pineu.Domain.Entities.Types;

namespace Pineu.Domain.Repositories.Types;

public interface IDurationOfUseTypeRepository {
    Task<IEnumerable<DurationOfUseType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default);
}