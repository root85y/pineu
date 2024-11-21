using Pineu.Domain.Entities.Types;

namespace Pineu.Domain.Repositories.Types;

public interface IOtherDiseaseTypeRepository {
    Task<IEnumerable<OtherDiseaseType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default);
}