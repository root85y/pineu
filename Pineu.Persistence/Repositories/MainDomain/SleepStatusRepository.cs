using Pineu.Persistence.Specifications.MainDomain.SleepStatuses;

namespace Pineu.Persistence.Repositories.MainDomain {
    internal class SleepStatusRepository(IRepository<SleepStatus, Guid> repository) : ISleepStatusRepository {
        public async Task AddAsync(SleepStatus sleepStatus, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(sleepStatus, cancellationToken);

        public async Task<PagedResponse<IEnumerable<SleepStatus>>> GetAllAsync(DateTime? from, DateTime? to, int? page, int? pageSize, Guid? userId, CancellationToken cancellationToken = default) {
            var specification = new GetAllSleepStatusesSpecification(from, to, userId);
            var count = await repository.CountAsync(specification, cancellationToken);

            if (page.HasValue && pageSize.HasValue)
                specification.ToPaged(page.Value, pageSize.Value);

            return new PagedResponse<IEnumerable<SleepStatus>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<PagedResponse<IEnumerable<SleepStatus>>> GetAllForPatientAsync(DateTime? from, DateTime? to, Guid? userId, CancellationToken cancellationToken = default) {
            var specification = new GetAllSleepStatusesForPatientSpecification(from, to, userId);
            var count = await repository.CountAsync(specification, cancellationToken);

            return new PagedResponse<IEnumerable<SleepStatus>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<SleepStatus?> GetAsync(Guid userId, DateTime? date, CancellationToken cancellationToken = default) =>
            await repository.FirstOrDefaultAsync(new GetSleepStatusByUserIdSpecification(userId, date), cancellationToken);

        public async Task UpdateAsync(SleepStatus sleepStatus, CancellationToken cancellationToken = default) =>
            await repository.UpdateAsync(sleepStatus, cancellationToken);
    }
}
