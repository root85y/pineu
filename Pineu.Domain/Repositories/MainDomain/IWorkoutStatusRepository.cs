namespace Pineu.Domain.Repositories.MainDomain;
public interface IWorkoutStatusRepository {
    Task UpdateAsync(WorkoutStatus workoutStatus, CancellationToken cancellationToken = default);
    Task AddAsync(WorkoutStatus workoutStatus, CancellationToken cancellationToken = default);
    Task<WorkoutStatus?> GetAsync(Guid userId, DateTime? date, CancellationToken cancellationToken = default);
    Task<PagedResponse<IEnumerable<WorkoutStatus>>> GetAllAsync(DateTime? from, DateTime? to, int? page, int? pageSize, Guid? userId,
        CancellationToken cancellationToken = default);

    Task<PagedResponse<IEnumerable<WorkoutStatus>>> GetAllForPatientAsync(DateTime? from, DateTime? to, Guid? userId,
    CancellationToken cancellationToken = default);
}
