using Pineu.Domain.Entities.Types;

namespace Pineu.Persistence.Specifications.Types;

internal class GetAllParentFamilyRelationshipTypeSpecification : Specification<ParentFamilyRelationshipType> {
    public GetAllParentFamilyRelationshipTypeSpecification(IEnumerable<short>? ids, string? search) {
        Query.Where(t => ids.Contains(t.Id), ids != null)
            .Where(t => t.EnglishName.Contains(search) || t.FarsiName.Contains(search), !string.IsNullOrWhiteSpace(search));
    }
}