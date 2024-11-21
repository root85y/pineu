using Pineu.Domain.Entities.Types;
using Pineu.Domain.Repositories.Types;
using Pineu.Persistence.Specifications.Types;

namespace Pineu.Persistence.Repositories.Types;

internal class AetiologyTypeRepository(IRepository<AetiologyType, short> repository) : IAetiologyTypeRepository {
    public async Task<IEnumerable<AetiologyType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllAetiologyTypesSpecification(ids, search), cancellationToken);
}