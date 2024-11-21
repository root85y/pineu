namespace Pineu.Application.DbBackups.DatabaseBackups.Command;
public sealed record MakeDatabaseBackupCommand(string ContentRootPath) : ICommand<string>;
