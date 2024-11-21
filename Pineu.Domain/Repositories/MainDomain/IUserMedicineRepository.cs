namespace Pineu.Domain.Repositories.MainDomain;

public interface IUserMedicineRepository
{
    Task UpdateAsync(UserMedicine userMedicine, CancellationToken cancellationToken = default);
    Task AddAsync(UserMedicine userMedicine, CancellationToken cancellationToken = default);
    Task<IEnumerable<UserMedicine>> GetAllAsync(Guid userId, string? search, IEnumerable<MedicineType>? medicineTypes,
        CancellationToken cancellationToken = default);
    Task<UserMedicine?> GetAsync(Guid id, CancellationToken cancellationToken = default);
}