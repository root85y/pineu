using Pineu.Domain.Entities.Medical;

namespace Pineu.Domain.Repositories.Medical;

public interface IPastAntiepilepticMedicineRepository {
    Task UpdateRangeAsync(IEnumerable<PastAntiepilepticMedicine> pam, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<PastAntiepilepticMedicine> pam, CancellationToken cancellationToken = default);
    Task DeleteRangeAsync(IEnumerable<PastAntiepilepticMedicine> pam, CancellationToken cancellationToken = default);
    Task<IEnumerable<PastAntiepilepticMedicine>> GetAllAsync(IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<PastAntiepilepticMedicine>> GetAllAsync(IEnumerable<Guid?> ids,
        CancellationToken cancellationToken = default);
}