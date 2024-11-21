using Pineu.Domain.Entities.Types;
using Pineu.Domain.Repositories.Types;
using Pineu.Persistence.Specifications.Types;

namespace Pineu.Persistence.Repositories.Types;

internal class ConsciousnessTypeRepository (IRepository<ConsciousnessType, short> repository) : IConsciousnessTypeRepository {
    public async Task<IEnumerable<ConsciousnessType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllConsciousnessTypeSpecification(ids, search), cancellationToken);
}