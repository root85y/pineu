using Pineu.Domain.Entities.Types;

namespace Pineu.Domain.Repositories.Types;

public interface IParentFamilyRelationshipTypeRepository {
    Task<IEnumerable<ParentFamilyRelationshipType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default);
}