using Pineu.Domain.Entities.Medical;

namespace Pineu.Domain.Repositories.Medical;

public interface IOtherMedicineRepository {
    Task UpdateRangeAsync(IEnumerable<OtherMedicine> om, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<OtherMedicine> om, CancellationToken cancellationToken = default);
    Task DeleteRangeAsync(IEnumerable<OtherMedicine> om, CancellationToken cancellationToken = default);
    Task<IEnumerable<OtherMedicine>> GetAllAsync(IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<OtherMedicine>> GetAllAsync(IEnumerable<Guid?> ids,
        CancellationToken cancellationToken = default);
}