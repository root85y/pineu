using Pineu.Domain.Entities.Types;

namespace Pineu.Domain.Repositories.Types;

public interface IDrugTypeRepository {
    Task<IEnumerable<DrugType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default);
}