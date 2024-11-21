using Pineu.Domain.Entities.Medical;

namespace Pineu.Persistence.Specifications.Medical;

internal class GetAllFamilyDiseaseHistorySpecification : Specification<FamilyDiseaseHistory> {
    public GetAllFamilyDiseaseHistorySpecification(IEnumerable<Guid> ids)
    {
        Query.Where(pam => ids.Contains(pam.Id));
    }
    public GetAllFamilyDiseaseHistorySpecification(IEnumerable<Guid?> ids)
    {
        Query.Where(pam => ids.Contains(pam.Id));
    }
}