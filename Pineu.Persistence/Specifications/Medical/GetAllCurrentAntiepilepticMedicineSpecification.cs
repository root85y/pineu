using Pineu.Domain.Entities.Medical;

namespace Pineu.Persistence.Specifications.Medical;

internal class GetAllCurrentAntiepilepticMedicineSpecification : Specification<CurrentAntiepilepticMedicine> {
    public GetAllCurrentAntiepilepticMedicineSpecification(IEnumerable<Guid> ids)
    {
        Query.Where(pam => ids.Contains(pam.Id));
    }
    public GetAllCurrentAntiepilepticMedicineSpecification(IEnumerable<Guid?> ids)
    {
        Query.Where(pam => ids.Contains(pam.Id));
    }
}