using Pineu.Persistence.Specifications.MainDomain.DoctorPrescriptions;

namespace Pineu.Persistence.Repositories.MainDomain {
    internal class DoctorPrescriptionRepository(IRepository<DoctorPrescription, Guid> repository) : IDoctorPrescriptionRepository {
        public async Task AddAsync(DoctorPrescription doctorPrescription, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(doctorPrescription, cancellationToken);

        public async Task<PagedResponse<IEnumerable<DoctorPrescription>>> GetAllAsync(DateTime? from, DateTime? to, int? page, int? pageSize,
            Guid userId, CancellationToken cancellationToken = default) {
            var specification = new GetAllDoctorPrescriptionsSpecification(from, to, userId);
            var count = await repository.CountAsync(specification, cancellationToken);

            if (page.HasValue && pageSize.HasValue)
                specification.ToPaged(page.Value, pageSize.Value);

            return new PagedResponse<IEnumerable<DoctorPrescription>>(await repository.ListAsync(specification, cancellationToken), count);
        }
    }
}
