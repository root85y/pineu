using Pineu.Persistence.Specifications.MainDomain.NutritionStatuses;

namespace Pineu.Persistence.Repositories.MainDomain {
    internal class NutritionStatusRepository(IRepository<NutritionStatus, Guid> repository) : INutritionStatusRepository {
        public async Task AddAsync(NutritionStatus nutritionStatus, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(nutritionStatus, cancellationToken);

        public async Task<PagedResponse<IEnumerable<NutritionStatus>>> GetAllAsync(DateTime? from, DateTime? to, int? page, int? pageSize, Guid? userId, CancellationToken cancellationToken = default) {
            var specification = new GetAllNutritionStatusesSpecification(from, to, userId);
            var count = await repository.CountAsync(specification, cancellationToken);

            if (page.HasValue && pageSize.HasValue)
                specification.ToPaged(page.Value, pageSize.Value);

            return new PagedResponse<IEnumerable<NutritionStatus>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<PagedResponse<IEnumerable<NutritionStatus>>> GetAllForPatientAsync(DateTime? from, DateTime? to, Guid? userId, CancellationToken cancellationToken = default) {
            var specification = new GetAllNutritionStatusesForPatientSpecification(from, to, userId);
            var count = await repository.CountAsync(specification, cancellationToken);

            return new PagedResponse<IEnumerable<NutritionStatus>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<NutritionStatus?> GetAsync(Guid userId, DateTime? date, CancellationToken cancellationToken = default) =>
            await repository.FirstOrDefaultAsync(new GetNutritionStatusByUserIdSpecification(userId, date), cancellationToken);

        public async Task UpdateAsync(NutritionStatus nutritionStatus, CancellationToken cancellationToken = default) =>
            await repository.UpdateAsync(nutritionStatus, cancellationToken);
    }
}
