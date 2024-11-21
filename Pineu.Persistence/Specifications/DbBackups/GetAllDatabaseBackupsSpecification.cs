namespace Pineu.Persistence.Specifications.DbBackups {
    internal class GetAllDatabaseBackupsSpecification : Specification<DatabaseBackup> {
        public GetAllDatabaseBackupsSpecification() {
            Query.AsNoTracking().OrderByDescending(d => d.CreatedAt);
        }
    }
}
