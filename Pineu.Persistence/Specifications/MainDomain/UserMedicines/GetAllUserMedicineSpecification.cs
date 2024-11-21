namespace Pineu.Persistence.Specifications.MainDomain.UserMedicines
{
    internal class GetAllUserMedicineSpecification : Specification<UserMedicine>
    {
        public GetAllUserMedicineSpecification(Guid userId, string? search, IEnumerable<MedicineType>? medicineTypes)
        {
            Query.Where(um => um.UserId == userId)
                .Where(um => um.Name.Contains(search), !string.IsNullOrWhiteSpace(search))
                .Where(dm => dm.Type != null && medicineTypes.Contains(dm.Type.Value),
                    medicineTypes != null && medicineTypes.Any())
                .AsNoTracking().OrderByDescending(um => um.CreatedAt);
        }
    }
}
