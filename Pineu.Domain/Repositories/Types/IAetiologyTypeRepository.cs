using Pineu.Domain.Entities.Types;

namespace Pineu.Domain.Repositories.Types;

public interface IAetiologyTypeRepository {
    Task<IEnumerable<AetiologyType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default);
}