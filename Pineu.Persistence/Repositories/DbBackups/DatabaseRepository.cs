using Pineu.Domain.Repositories.DbBackups;
using Pineu.Persistence.Specifications.DbBackups;

namespace Pineu.Persistence.Repositories.MainDomain {
    public class DatabaseRepository(IRepository<DatabaseBackup, Guid> repository) : IDatabaseBackupRepository {
        public async Task AddAsync(DatabaseBackup databaseBackup, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(databaseBackup, cancellationToken);

        public async Task<PagedResponse<IEnumerable<DatabaseBackup>>> GetAllAsync(int? page, int? pageSize, CancellationToken cancellationToken = default) {
            var specification = new GetAllDatabaseBackupsSpecification();
            var count = await repository.CountAsync(specification, cancellationToken);

            if (page.HasValue && pageSize.HasValue) {
                specification.ToPaged(page.Value, pageSize.Value);
            }

            return new PagedResponse<IEnumerable<DatabaseBackup>>(await repository.ListAsync(specification, cancellationToken), count);
        }

        public async Task<DatabaseBackup?> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
            await repository.GetByIdAsync(id, cancellationToken);

        public async Task RemoveAsync(DatabaseBackup databaseBackup, CancellationToken cancellationToken = default) =>
            await repository.DeleteAsync(databaseBackup, cancellationToken);
    }
}
