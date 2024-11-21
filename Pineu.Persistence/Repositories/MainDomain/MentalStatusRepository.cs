using Pineu.Persistence.Specifications.MainDomain.MentalStatuses;

namespace Pineu.Persistence.Repositories.MainDomain {
    internal class MentalStatusRepository(IRepository<MentalStatus, Guid> repository) : IMentalStatusRepository {
        public async Task AddAsync(MentalStatus mentalStatus, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(mentalStatus, cancellationToken);

        public async Task<PagedResponse<IEnumerable<MentalStatus>>> GetAllAsync(DateTime? from, DateTime? to, int? page, int? pageSize, Guid? userId, CancellationToken cancellationToken = default) {
            var specification = new GetAllMentalStatusesSpecification(from, to, userId);
            var count = await repository.CountAsync(specification, cancellationToken);

            if (page.HasValue && pageSize.HasValue)
                specification.ToPaged(page.Value, pageSize.Value);

            return new PagedResponse<IEnumerable<MentalStatus>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<PagedResponse<IEnumerable<MentalStatus>>> GetAllForPatientAsync(DateTime? from, DateTime? to, Guid? userId, CancellationToken cancellationToken = default) {
            var specification = new GetAllMentalStatusesForPatientSpecification(from, to, userId);
            var count = await repository.CountAsync(specification, cancellationToken);

            return new PagedResponse<IEnumerable<MentalStatus>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<MentalStatus?> GetAsync(Guid userId, DateTime? date, CancellationToken cancellationToken = default) =>
            await repository.FirstOrDefaultAsync(new GetMentalStatusByUserIdSpecification(userId, date), cancellationToken);

        public async Task UpdateAsync(MentalStatus mentalStatus, CancellationToken cancellationToken = default) =>
            await repository.UpdateAsync(mentalStatus, cancellationToken);
    }
}
