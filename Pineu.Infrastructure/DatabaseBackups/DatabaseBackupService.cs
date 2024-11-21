using Pineu.Application.Abstractions.DatabaseBackups;
using MySql.Data.MySqlClient;
using Shared.Constants;

namespace Pineu.Infrastructure.DatabaseBackups
{
    public class DatabaseBackupService : IDatabaseBackupService
    {
        public void MakeBackup(string outputFolderPath)
        {
            using MySqlConnection conn = new(DBSettings.ApplicationDbContextConnectionString);
            using MySqlCommand cmd = new();
            using MySqlBackup mb = new(cmd);

            cmd.Connection = conn;
            conn.Open();
            mb.ExportToFile(outputFolderPath);
            conn.Close();
        }
    }
}
