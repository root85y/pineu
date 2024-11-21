using Pineu.Domain.Entities.Medical;

namespace Pineu.Domain.Repositories.Medical;

public interface IDrugConsumptionRepository {
    Task UpdateRangeAsync(IEnumerable<DrugConsumption> cam, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<DrugConsumption> cam, CancellationToken cancellationToken = default);
    Task DeleteRangeAsync(IEnumerable<DrugConsumption> cam, CancellationToken cancellationToken = default);
    Task<IEnumerable<DrugConsumption>> GetAllAsync(IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<DrugConsumption>> GetAllAsync(IEnumerable<Guid?> ids,
        CancellationToken cancellationToken = default);
}