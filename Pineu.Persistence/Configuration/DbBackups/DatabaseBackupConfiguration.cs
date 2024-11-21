namespace Pineu.Persistence.Configuration.DbBackups {
    internal class DatabaseBackupConfiguration : IEntityTypeConfiguration<DatabaseBackup> {
        public void Configure(EntityTypeBuilder<DatabaseBackup> builder) {
            builder.ToTable(TableNames.DatabaseBackup);
        }
    }
}
