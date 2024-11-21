using Pineu.Domain.Entities.Types;
using Pineu.Domain.Repositories.Types;
using Pineu.Persistence.Specifications.Types;

namespace Pineu.Persistence.Repositories.Types;

internal class DurationOfUseTypeRepository (IRepository<DurationOfUseType, short> repository) : IDurationOfUseTypeRepository {
    public async Task<IEnumerable<DurationOfUseType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllDurationOfUseTypeSpecification(ids, search), cancellationToken);
}