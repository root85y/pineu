using Pineu.Domain.Entities.Types;
using Pineu.Domain.Repositories.Types;
using Pineu.Persistence.Specifications.Types;

namespace Pineu.Persistence.Repositories.Types;

internal class EpilepsyTypeRepository(IRepository<EpilepsyType, short> repository) : IEpilepsyTypeRepository
{
    public async Task<IEnumerable<EpilepsyType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default)
        => await repository.ListAsync(new GetAllEpilepsyTypeSpecification(ids, search), cancellationToken);
}