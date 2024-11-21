using Pineu.Domain.Entities.Medical;

namespace Pineu.Persistence.Specifications.Medical;

internal class GetAllDrugConsumptionSpecification : Specification<DrugConsumption> {
    public GetAllDrugConsumptionSpecification(IEnumerable<Guid> ids)
    {
        Query.Where(pam => ids.Contains(pam.Id));
    }
    public GetAllDrugConsumptionSpecification(IEnumerable<Guid?> ids)
    {
        Query.Where(pam => ids.Contains(pam.Id));
    }
}