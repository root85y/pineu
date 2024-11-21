namespace Pineu.Application.DbBackups.DatabaseBackups.Command.Handlers;

internal class DeleteDatabaseBackupCommandHandler(IDatabaseBackupRepository repository)
    : ICommandHandler<DeleteDatabaseBackupCommand> {
    public async Task<Result> Handle(DeleteDatabaseBackupCommand request, CancellationToken cancellationToken) {
        var backup = await repository.GetAsync(request.Id, cancellationToken);
        if (backup == null) return Result.Failure<Guid>(DomainErrors.DatabaseBackup.DatabaseBackupNotFound);

        var path = backup.FilePath.Replace("api", "app");
        if (File.Exists(path)) File.Delete(path);

        await repository.RemoveAsync(backup, cancellationToken);
        return Result.Success();
    }
}
