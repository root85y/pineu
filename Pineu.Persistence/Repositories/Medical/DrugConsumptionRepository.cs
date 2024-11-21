using Pineu.Domain.Entities.Medical;
using Pineu.Domain.Repositories.Medical;
using Pineu.Persistence.Specifications.Medical;

namespace Pineu.Persistence.Repositories.Medical;

internal class DrugConsumptionRepository(IRepository<DrugConsumption, Guid> repository) : IDrugConsumptionRepository
{
    public async Task UpdateRangeAsync(IEnumerable<DrugConsumption> cam,
        CancellationToken cancellationToken = default) =>
        await repository.UpdateRangeAsync(cam, cancellationToken);

    public async Task AddRangeAsync(IEnumerable<DrugConsumption> cam,
        CancellationToken cancellationToken = default) =>
        await repository.AddRangeAsync(cam, cancellationToken);

    public async Task DeleteRangeAsync(IEnumerable<DrugConsumption> cam,
        CancellationToken cancellationToken = default) =>
        await repository.DeleteRangeAsync(cam, cancellationToken);

    public async Task<IEnumerable<DrugConsumption>> GetAllAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllDrugConsumptionSpecification(ids), cancellationToken);

    public async Task<IEnumerable<DrugConsumption>> GetAllAsync(IEnumerable<Guid?> ids, CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllDrugConsumptionSpecification(ids), cancellationToken);
}