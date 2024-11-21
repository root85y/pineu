using Pineu.Domain.Entities.Medical;
using Pineu.Domain.Repositories.Medical;
using Pineu.Persistence.Specifications.Medical;

namespace Pineu.Persistence.Repositories.Medical;

internal class OtherMedicineRepository(IRepository<OtherMedicine, Guid> repository) : IOtherMedicineRepository
{
    public async Task UpdateRangeAsync(IEnumerable<OtherMedicine> om, CancellationToken cancellationToken = default) =>
        await repository.UpdateRangeAsync(om, cancellationToken);

    public async Task AddRangeAsync(IEnumerable<OtherMedicine> om, CancellationToken cancellationToken = default) =>
        await repository.AddRangeAsync(om, cancellationToken);

    public async Task DeleteRangeAsync(IEnumerable<OtherMedicine> om, CancellationToken cancellationToken = default) =>
        await repository.DeleteRangeAsync(om, cancellationToken);

    public async Task<IEnumerable<OtherMedicine>> GetAllAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllOtherMedicineSpecification(ids), cancellationToken);

    public async Task<IEnumerable<OtherMedicine>> GetAllAsync(IEnumerable<Guid?> ids, CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllOtherMedicineSpecification(ids), cancellationToken);
}