using Pineu.Domain.Entities.Medical;

namespace Pineu.Persistence.Specifications.Medical;

internal class GetAllPastAntiepilepticMedicineSpecification : Specification<PastAntiepilepticMedicine> {
    public GetAllPastAntiepilepticMedicineSpecification(IEnumerable<Guid> ids)
    {
        Query.Where(pam => ids.Contains(pam.Id));
    }
    public GetAllPastAntiepilepticMedicineSpecification(IEnumerable<Guid?> ids)
    {
        Query.Where(pam => ids.Contains(pam.Id));
    }
}