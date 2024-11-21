using Pineu.Domain.Entities.Medical;
using Pineu.Domain.Repositories.Medical;
using Pineu.Persistence.Specifications.Medical;

namespace Pineu.Persistence.Repositories.Medical;

internal class CurrentAntiepilepticMedicineRepository(IRepository<CurrentAntiepilepticMedicine, Guid> repository) : ICurrentAntiepilepticMedicineRepository {
    public async Task UpdateRangeAsync(IEnumerable<CurrentAntiepilepticMedicine> cam,
        CancellationToken cancellationToken = default) =>
        await repository.UpdateRangeAsync(cam, cancellationToken);

    public async Task AddRangeAsync(IEnumerable<CurrentAntiepilepticMedicine> cam,
        CancellationToken cancellationToken = default) =>
        await repository.AddRangeAsync(cam, cancellationToken);

    public async Task DeleteRangeAsync(IEnumerable<CurrentAntiepilepticMedicine> cam,
        CancellationToken cancellationToken = default) =>
        await repository.DeleteRangeAsync(cam, cancellationToken);

    public async Task<IEnumerable<CurrentAntiepilepticMedicine>> GetAllAsync(IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllCurrentAntiepilepticMedicineSpecification(ids), cancellationToken);

    public async Task<IEnumerable<CurrentAntiepilepticMedicine>> GetAllAsync(IEnumerable<Guid?> ids,
        CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllCurrentAntiepilepticMedicineSpecification(ids), cancellationToken);
}