using Pineu.Domain.Entities.DbBackups;

namespace Pineu.Domain.Repositories.DbBackups;
public interface IDatabaseBackupRepository {
    Task AddAsync(DatabaseBackup databaseBackup, CancellationToken cancellationToken = default);
    Task<PagedResponse<IEnumerable<DatabaseBackup>>> GetAllAsync(int? page, int? pageSize,
        CancellationToken cancellationToken = default);
    Task<DatabaseBackup?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task RemoveAsync(DatabaseBackup databaseBackup, CancellationToken cancellationToken = default);
}
