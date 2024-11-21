namespace Pineu.Domain.Repositories.MainDomain;
public interface ISleepStatusRepository {
    Task UpdateAsync(SleepStatus sleepStatus, CancellationToken cancellationToken = default);
    Task AddAsync(SleepStatus sleepStatus, CancellationToken cancellationToken = default);
    Task<SleepStatus?> GetAsync(Guid userId, DateTime? date, CancellationToken cancellationToken = default);
    Task<PagedResponse<IEnumerable<SleepStatus>>> GetAllAsync(DateTime? from, DateTime? to, int? page, int? pageSize, Guid? userId,
        CancellationToken cancellationToken = default);
    Task<PagedResponse<IEnumerable<SleepStatus>>> GetAllForPatientAsync(
        DateTime? from,
        DateTime? to,
        Guid? userId,
    CancellationToken cancellationToken = default);
}
