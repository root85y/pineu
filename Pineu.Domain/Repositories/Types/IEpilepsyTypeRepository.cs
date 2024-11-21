using Pineu.Domain.Entities.Types;

namespace Pineu.Domain.Repositories.Types; 
public interface IEpilepsyTypeRepository {
    Task<IEnumerable<EpilepsyType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default);
}
