namespace Pineu.Domain.Repositories.MainDomain;
public interface IMentalStatusRepository {
    Task UpdateAsync(MentalStatus mentalStatus, CancellationToken cancellationToken = default);
    Task AddAsync(MentalStatus mentalStatus, CancellationToken cancellationToken = default);
    Task<MentalStatus?> GetAsync(Guid userId, DateTime? date, CancellationToken cancellationToken = default);
    Task<PagedResponse<IEnumerable<MentalStatus>>> GetAllAsync(DateTime? from, DateTime? to, int? page, int? pageSize, Guid? userId,
        CancellationToken cancellationToken = default);
    Task<PagedResponse<IEnumerable<MentalStatus>>> GetAllForPatientAsync(DateTime? from, DateTime? to, Guid? userId,
    CancellationToken cancellationToken = default);
}
