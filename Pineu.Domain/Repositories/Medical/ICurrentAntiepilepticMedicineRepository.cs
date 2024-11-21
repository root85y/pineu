using Pineu.Domain.Entities.Medical;

namespace Pineu.Domain.Repositories.Medical;

public interface ICurrentAntiepilepticMedicineRepository {
    Task UpdateRangeAsync(IEnumerable<CurrentAntiepilepticMedicine> cam, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<CurrentAntiepilepticMedicine> cam, CancellationToken cancellationToken = default);
    Task DeleteRangeAsync(IEnumerable<CurrentAntiepilepticMedicine> cam, CancellationToken cancellationToken = default);
    Task<IEnumerable<CurrentAntiepilepticMedicine>> GetAllAsync(IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<CurrentAntiepilepticMedicine>> GetAllAsync(IEnumerable<Guid?> ids,
        CancellationToken cancellationToken = default);
}