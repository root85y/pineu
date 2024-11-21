using Pineu.Domain.Entities.Types;
using Pineu.Domain.Repositories.Types;
using Pineu.Persistence.Specifications.Types;

namespace Pineu.Persistence.Repositories.Types;

internal class ParentFamilyRelationshipTypeRepository (IRepository<ParentFamilyRelationshipType, short> repository) 
    : IParentFamilyRelationshipTypeRepository {
    public async Task<IEnumerable<ParentFamilyRelationshipType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllParentFamilyRelationshipTypeSpecification(ids, search), cancellationToken);
}