using Pineu.Persistence.Specifications.MainDomain.WorkoutStatuses;

namespace Pineu.Persistence.Repositories.MainDomain {
    internal class WorkoutStatusRepository(IRepository<WorkoutStatus, Guid> repository) : IWorkoutStatusRepository {
        public async Task AddAsync(WorkoutStatus workoutStatus, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(workoutStatus, cancellationToken);

        public async Task<PagedResponse<IEnumerable<WorkoutStatus>>> GetAllAsync(DateTime? from, DateTime? to, int? page, int? pageSize, Guid? userId, CancellationToken cancellationToken = default) {
            var specification = new GetAllWorkoutStatusesSpecification(from, to, userId);
            var count = await repository.CountAsync(specification, cancellationToken);

            if (page.HasValue && pageSize.HasValue)
                specification.ToPaged(page.Value, pageSize.Value);

            return new PagedResponse<IEnumerable<WorkoutStatus>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<PagedResponse<IEnumerable<WorkoutStatus>>> GetAllForPatientAsync(DateTime? from, DateTime? to, Guid? userId, CancellationToken cancellationToken = default) {
            var specification = new GetAllWorkoutStatusesForPatientSpecification(from, to, userId);
            var count = await repository.CountAsync(specification, cancellationToken);

            return new PagedResponse<IEnumerable<WorkoutStatus>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<WorkoutStatus?> GetAsync(Guid userId, DateTime? date, CancellationToken cancellationToken = default) =>
            await repository.FirstOrDefaultAsync(new GetWorkoutStatusByUserIdSpecification(userId, date), cancellationToken);

        public async Task UpdateAsync(WorkoutStatus workoutStatus, CancellationToken cancellationToken = default) =>
            await repository.UpdateAsync(workoutStatus, cancellationToken);
    }
}
