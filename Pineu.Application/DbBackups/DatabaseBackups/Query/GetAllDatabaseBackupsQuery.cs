using Pineu.Application.DbBackups.DatabaseBackups.Query.DTOs;

namespace Pineu.Application.DbBackups.DatabaseBackups.Query;
public sealed record GetAllDatabaseBackupsQuery(int? Page, int? PageSize)
    : IQuery<PagedResponse<IEnumerable<DatabaseBackupResponse>>>;
