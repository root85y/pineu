using Pineu.Domain.Entities.Medical;

namespace Pineu.Domain.Repositories.Medical;

public interface IFamilyDiseaseHistoryRepository {
    Task UpdateRangeAsync(IEnumerable<FamilyDiseaseHistory> fdh, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<FamilyDiseaseHistory> fdh, CancellationToken cancellationToken = default);
    Task DeleteRangeAsync(IEnumerable<FamilyDiseaseHistory> fdh, CancellationToken cancellationToken = default);
    Task<IEnumerable<FamilyDiseaseHistory>> GetAllAsync(IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<FamilyDiseaseHistory>> GetAllAsync(IEnumerable<Guid?> ids,
        CancellationToken cancellationToken = default);
}