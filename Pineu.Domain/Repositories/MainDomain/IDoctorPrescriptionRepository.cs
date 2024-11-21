namespace Pineu.Domain.Repositories.MainDomain;
public interface IDoctorPrescriptionRepository {
    Task AddAsync(DoctorPrescription doctorPrescription, CancellationToken cancellationToken = default);
    Task<PagedResponse<IEnumerable<DoctorPrescription>>> GetAllAsync(DateTime? from, DateTime? to, int? page, int? pageSize, Guid userId,
        CancellationToken cancellationToken = default);
}
