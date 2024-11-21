using Pineu.Domain.Entities.Types;
using Pineu.Domain.Repositories.Types;
using Pineu.Persistence.Specifications.Types;

namespace Pineu.Persistence.Repositories.Types;

internal class OtherDiseaseTypeRepository (IRepository<OtherDiseaseType, short> repository) : IOtherDiseaseTypeRepository {
    public async Task<IEnumerable<OtherDiseaseType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllOtherDiseaseTypeSpecification(ids, search), cancellationToken);
}