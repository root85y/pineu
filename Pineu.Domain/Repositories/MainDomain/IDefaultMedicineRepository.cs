namespace Pineu.Domain.Repositories.MainDomain;

public interface IDefaultMedicineRepository
{
    Task<IEnumerable<DefaultMedicine>> GetAllAsync(IEnumerable<MedicineType>? medicineTypes,
        string? search, CancellationToken cancellationToken = default);
}