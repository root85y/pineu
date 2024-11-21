using Pineu.Domain.Entities.Types;

namespace Pineu.Domain.Repositories.Types;

public interface ISeizureTypeRepository {
    Task<IEnumerable<SeizureType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default);
}