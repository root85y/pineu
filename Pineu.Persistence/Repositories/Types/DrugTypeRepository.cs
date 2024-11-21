using Pineu.Domain.Entities.Types;
using Pineu.Domain.Repositories.Types;
using Pineu.Persistence.Specifications.Types;

namespace Pineu.Persistence.Repositories.Types;

internal class DrugTypeRepository (IRepository<DrugType, short> repository) : IDrugTypeRepository {
    public async Task<IEnumerable<DrugType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllDrugTypeSpecification(ids, search), cancellationToken);
}