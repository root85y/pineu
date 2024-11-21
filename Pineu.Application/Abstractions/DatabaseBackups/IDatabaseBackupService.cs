namespace Pineu.Application.Abstractions.DatabaseBackups;
public interface IDatabaseBackupService {
    void MakeBackup(string outputFolderPath);
}
