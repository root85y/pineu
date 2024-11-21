namespace Pineu.Application.DbBackups.DatabaseBackups.Query.DTOs;
public sealed record DatabaseBackupResponse(Guid Id, string FilePath, DateTime CreatedAt);
