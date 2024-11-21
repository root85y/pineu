namespace Pineu.Domain.Repositories.SystemFiles;
public interface ISystemFileRepository {
    Task AddAsync(SystemFile systemFile, CancellationToken cancellationToken);
    Task<SystemFile?> GetAsync(Guid id, CancellationToken cancellationToken);
    Task RemoveAsync(SystemFile systemFile, CancellationToken cancellationToken);
}
