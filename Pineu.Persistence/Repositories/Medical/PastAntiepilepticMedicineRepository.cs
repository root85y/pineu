using Pineu.Domain.Entities.Medical;
using Pineu.Domain.Repositories.Medical;
using Pineu.Persistence.Specifications.Medical;

namespace Pineu.Persistence.Repositories.Medical;

internal class PastAntiepilepticMedicineRepository(IRepository<PastAntiepilepticMedicine, Guid> repository) : IPastAntiepilepticMedicineRepository {
    public async Task UpdateRangeAsync(IEnumerable<PastAntiepilepticMedicine> pam,
        CancellationToken cancellationToken = default) =>
        await repository.UpdateRangeAsync(pam, cancellationToken);

    public async Task AddRangeAsync(IEnumerable<PastAntiepilepticMedicine> pam,
        CancellationToken cancellationToken = default) =>
        await repository.AddRangeAsync(pam, cancellationToken);

    public async Task DeleteRangeAsync(IEnumerable<PastAntiepilepticMedicine> pam,
        CancellationToken cancellationToken = default) =>
        await repository.DeleteRangeAsync(pam, cancellationToken);

    public async Task<IEnumerable<PastAntiepilepticMedicine>> GetAllAsync(IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllPastAntiepilepticMedicineSpecification(ids), cancellationToken);
    
    public async Task<IEnumerable<PastAntiepilepticMedicine>> GetAllAsync(IEnumerable<Guid?> ids,
        CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllPastAntiepilepticMedicineSpecification(ids), cancellationToken);


}