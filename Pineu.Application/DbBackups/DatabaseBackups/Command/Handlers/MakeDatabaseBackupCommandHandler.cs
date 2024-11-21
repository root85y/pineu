using Pineu.Application.Abstractions.DatabaseBackups;
using Pineu.Domain.Entities.DbBackups;

namespace Pineu.Application.DbBackups.DatabaseBackups.Command.Handlers;

internal class MakeDatabaseBackupCommandHandler(IDatabaseBackupService service, IDatabaseBackupRepository repository)
    : ICommandHandler<MakeDatabaseBackupCommand, string> {
    public async Task<Result<string>> Handle(MakeDatabaseBackupCommand request, CancellationToken cancellationToken) {
        string path = Path.Combine(request.ContentRootPath, "dbBackups");

        var id = Guid.NewGuid();
        string outputPath = path + $"/{id}.sql";
        service.MakeBackup(outputPath);

        var secondPath = Path.Combine(request.ContentRootPath, "uploads", $"{id}.zip");
        ZipFile.CreateFromDirectory(path, secondPath);

        var backup = DatabaseBackup.Create(id, secondPath.Replace("app", "api"));
        await repository.AddAsync(backup, cancellationToken);

        File.Delete(outputPath);

        return path;
    }
}
