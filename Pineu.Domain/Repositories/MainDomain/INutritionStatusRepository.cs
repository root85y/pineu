namespace Pineu.Domain.Repositories.MainDomain;
public interface INutritionStatusRepository {
    Task UpdateAsync(NutritionStatus nutritionStatus, CancellationToken cancellationToken = default);
    Task AddAsync(NutritionStatus nutritionStatus, CancellationToken cancellationToken = default);
    Task<NutritionStatus?> GetAsync(Guid userId, DateTime? date, CancellationToken cancellationToken = default);
    Task<PagedResponse<IEnumerable<NutritionStatus>>> GetAllAsync(DateTime? from, DateTime? to, int? page, int? pageSize, Guid? userId,
        CancellationToken cancellationToken = default);
    Task<PagedResponse<IEnumerable<NutritionStatus>>> GetAllForPatientAsync(DateTime? from, DateTime? to, Guid? userId,
    CancellationToken cancellationToken = default);
}
