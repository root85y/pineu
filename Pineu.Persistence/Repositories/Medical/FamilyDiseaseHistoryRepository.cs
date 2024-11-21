using Pineu.Domain.Entities.Medical;
using Pineu.Domain.Repositories.Medical;
using Pineu.Persistence.Specifications.Medical;

namespace Pineu.Persistence.Repositories.Medical;

internal class FamilyDiseaseHistoryRepository(IRepository<FamilyDiseaseHistory, Guid> repository) : IFamilyDiseaseHistoryRepository
{
    public async Task UpdateRangeAsync(IEnumerable<FamilyDiseaseHistory> fdh,
        CancellationToken cancellationToken = default) =>
        await repository.UpdateRangeAsync(fdh, cancellationToken);

    public async Task AddRangeAsync(IEnumerable<FamilyDiseaseHistory> fdh,
        CancellationToken cancellationToken = default) =>
        await repository.AddRangeAsync(fdh, cancellationToken);

    public async Task DeleteRangeAsync(IEnumerable<FamilyDiseaseHistory> fdh,
        CancellationToken cancellationToken = default) =>
        await repository.DeleteRangeAsync(fdh, cancellationToken);

    public async Task<IEnumerable<FamilyDiseaseHistory>> GetAllAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllFamilyDiseaseHistorySpecification(ids), cancellationToken);

    public async Task<IEnumerable<FamilyDiseaseHistory>> GetAllAsync(IEnumerable<Guid?> ids, CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllFamilyDiseaseHistorySpecification(ids), cancellationToken);
}