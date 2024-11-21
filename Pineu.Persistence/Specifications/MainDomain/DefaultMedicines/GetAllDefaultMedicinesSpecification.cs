namespace Pineu.Persistence.Specifications.MainDomain.DefaultMedicines
{
    internal sealed class GetAllDefaultMedicinesSpecification : Specification<DefaultMedicine>
    {
        public GetAllDefaultMedicinesSpecification(IEnumerable<MedicineType>? medicineTypes, string? search)
        {
            Query.Where(dm => medicineTypes.Contains(dm.Type), medicineTypes != null && medicineTypes.Any())
                .Where(dm => dm.Name.Contains(search), !string.IsNullOrWhiteSpace(search))
                .AsNoTracking().OrderByDescending(dm => dm.CreatedAt);
        }
    }
}
