using Pineu.Persistence.Specifications.MainDomain.UserMedicines;

namespace Pineu.Persistence.Repositories.MainDomain
{
    internal class UserMedicineRepository(IRepository<UserMedicine, Guid> repository) : IUserMedicineRepository
    {
        public async Task UpdateAsync(UserMedicine userMedicine, CancellationToken cancellationToken = default) =>
            await repository.UpdateAsync(userMedicine, cancellationToken);

        public async Task AddAsync(UserMedicine userMedicine, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(userMedicine, cancellationToken);

        public async Task<IEnumerable<UserMedicine>> GetAllAsync(Guid userId, string? search,
            IEnumerable<MedicineType>? medicineTypes, CancellationToken cancellationToken = default) =>
            await repository.ListAsync(new GetAllUserMedicineSpecification(userId, search, medicineTypes), cancellationToken);

        public async Task<UserMedicine?> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
            await repository.GetByIdAsync(id, cancellationToken);
    }
}
