using Pineu.Persistence.Specifications.MainDomain.DefaultMedicines;

namespace Pineu.Persistence.Repositories.MainDomain
{
    internal class DefaultMedicineRepository(IRepository<DefaultMedicine, int> repository) : IDefaultMedicineRepository
    {
        public async Task<IEnumerable<DefaultMedicine>> GetAllAsync(IEnumerable<MedicineType>? medicineTypes, 
            string? search, CancellationToken cancellationToken = default) =>
            await repository.ListAsync(new GetAllDefaultMedicinesSpecification(medicineTypes, search),
                cancellationToken);
    }
}
