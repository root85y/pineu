using Pineu.Domain.Entities.Types;

namespace Pineu.Domain.Repositories.Types;

public interface IMovementTypeRepository {
    Task<IEnumerable<MovementType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default);
}