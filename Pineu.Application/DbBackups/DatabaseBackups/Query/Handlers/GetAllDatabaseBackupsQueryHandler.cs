using Pineu.Application.DbBackups.DatabaseBackups.Query.DTOs;

namespace Pineu.Application.DbBackups.DatabaseBackups.Query.Handlers;

internal class GetAllDatabaseBackupsQueryHandler(IDatabaseBackupRepository repository)
    : IQueryHandler<GetAllDatabaseBackupsQuery, PagedResponse<IEnumerable<DatabaseBackupResponse>>> {
    public async Task<Result<PagedResponse<IEnumerable<DatabaseBackupResponse>>>> Handle(GetAllDatabaseBackupsQuery request, CancellationToken cancellationToken) {
        var backups = await repository.GetAllAsync(request.Page, request.PageSize, cancellationToken);

        var res = backups.List.Select(d => new DatabaseBackupResponse(d.Id, d.FilePath, d.CreatedAt.ToUniversalTime())).ToList();
        return new PagedResponse<IEnumerable<DatabaseBackupResponse>>(res, backups.Count);
    }
}
