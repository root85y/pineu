using Pineu.Domain.Entities.Medical;

namespace Pineu.Persistence.Specifications.Medical;

internal class GetAllOtherMedicineSpecification : Specification<OtherMedicine> {
    public GetAllOtherMedicineSpecification(IEnumerable<Guid> ids)
    {
        Query.Where(pam => ids.Contains(pam.Id));
    }
    public GetAllOtherMedicineSpecification(IEnumerable<Guid?> ids)
    {
        Query.Where(pam => ids.Contains(pam.Id));
    }
}