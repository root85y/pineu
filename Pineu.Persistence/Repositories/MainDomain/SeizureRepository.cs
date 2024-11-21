using Pineu.Persistence.Specifications.MainDomain.Seizures;

namespace Pineu.Persistence.Repositories.MainDomain {
    internal class SeizureRepository(IRepository<Seizure, Guid> repository) : ISeizureRepository {
        private readonly int MaximumSeizurePerDay = 5;

        public async Task AddAsync(Seizure seizure, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(seizure, cancellationToken);

        public async Task<PagedResponse<IEnumerable<Seizure>>> GetAllAsync(DateTime? from, DateTime? to, int? page, int? pageSize, Guid? userId, CancellationToken cancellationToken = default) {
            var specification = new GetAllSeizuresSpecification(from, to, userId);
            var count = await repository.CountAsync(specification, cancellationToken);

            if (page.HasValue && pageSize.HasValue)
                specification.ToPaged(page.Value, pageSize.Value);

            return new PagedResponse<IEnumerable<Seizure>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<PagedResponse<IEnumerable<Seizure>>> GetAllForPatientAsync(DateTime? from, DateTime? to, Guid? userId, CancellationToken cancellationToken = default) {
            var specification = new GetAllSeizuresForPatientSpecification(from, to, userId);
            var count = await repository.CountAsync(specification, cancellationToken);

            return new PagedResponse<IEnumerable<Seizure>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<Seizure?> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
            await repository.GetByIdAsync(id, cancellationToken);

        public async Task<bool> HasSubmittedTooMany(CancellationToken cancellationToken = default) =>
            await repository.CountAsync(new HasSubmittedTooManySeizuresSpecification(), cancellationToken) > MaximumSeizurePerDay;
    }
}
