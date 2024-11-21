namespace Pineu.Domain.Entities.SystemFiles;
public class SystemFile : Entity<Guid> {
    public string FilePath { get; private set; }
    public string Url { get; private set; }

    private SystemFile() {
    }

    private SystemFile(Guid id, string filePath, string url) : base(id) {
        FilePath = filePath;
        Url = url;
    }

    public static Result<SystemFile> Create(Guid id, string path) {
        var index = path.IndexOf(SystemFilesSettings.UploadPath, StringComparison.Ordinal);
        var url = Path.Combine("/api", path[index..]).Replace("\\", "/");
        if (Path.DirectorySeparatorChar == '\\')
            path = path.Replace('/', '\\');
        var res = new SystemFile(id, path, url);
        return Result.Success(res);
    }
}