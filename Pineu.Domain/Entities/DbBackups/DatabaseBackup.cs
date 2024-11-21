namespace Pineu.Domain.Entities.DbBackups;

public class DatabaseBackup : Entity<Guid> {
    public string FilePath { get; private set; }

    private DatabaseBackup(Guid id) : base(id) {
    }

    private DatabaseBackup(Guid id, string filePath) : this(id) {
        FilePath = filePath;
    }

    public static DatabaseBackup Create(Guid id, string filePath) =>
        new(id, filePath);
}
