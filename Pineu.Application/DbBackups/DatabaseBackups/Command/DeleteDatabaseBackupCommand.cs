namespace Pineu.Application.DbBackups.DatabaseBackups.Command;
public sealed record DeleteDatabaseBackupCommand(Guid Id) : ICommand;
