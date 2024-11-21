using Pineu.Domain.Entities.Types;
using Pineu.Domain.Repositories.Types;
using Pineu.Persistence.Specifications.Types;

namespace Pineu.Persistence.Repositories.Types;

internal class MovementTypeRepository (IRepository<MovementType, short> repository) : IMovementTypeRepository {
    public async Task<IEnumerable<MovementType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllMovementTypeSpecification(ids, search), cancellationToken);
}