using Pineu.Domain.Entities.Types;
using Pineu.Domain.Repositories.Types;
using Pineu.Persistence.Specifications.Types;

namespace Pineu.Persistence.Repositories.Types;

internal class SeizureTypeRepository (IRepository<SeizureType, short> repository) : ISeizureTypeRepository {
    public async Task<IEnumerable<SeizureType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllSeizureTypeSpecification(ids, search), cancellationToken);
}