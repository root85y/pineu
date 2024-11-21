namespace Pineu.Domain.Repositories.MainDomain;
public interface ISeizureRepository {
    Task AddAsync(Seizure seizure, CancellationToken cancellationToken = default);
    Task<Seizure?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<PagedResponse<IEnumerable<Seizure>>> GetAllAsync(DateTime? from, DateTime? to, int? page, int? pageSize, Guid? userId,
        CancellationToken cancellationToken = default);
    Task<PagedResponse<IEnumerable<Seizure>>> GetAllForPatientAsync(DateTime? from, DateTime? to, Guid? userId,
    CancellationToken cancellationToken = default);
    Task<bool> HasSubmittedTooMany(CancellationToken cancellationToken = default);
}