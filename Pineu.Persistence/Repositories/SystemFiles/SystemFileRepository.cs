using Pineu.Domain.Repositories.SystemFiles;
using Pineu.Persistence.Specifications.SystemFiles;

namespace Pineu.Persistence.Repositories.SystemFiles;

public class SystemFileRepository(IRepository<SystemFile, Guid> repository) : ISystemFileRepository {
    public async Task AddAsync(SystemFile systemFile, CancellationToken cancellationToken) =>
        await repository.AddAsync(systemFile, cancellationToken);

    public async Task<SystemFile?> GetAsync(Guid id, CancellationToken cancellationToken) =>
        await repository.FirstOrDefaultAsync(new SystemFileGetByIdSpecification(id), cancellationToken);

    public async Task RemoveAsync(SystemFile systemFile, CancellationToken cancellationToken) =>
        await repository.DeleteAsync(systemFile, cancellationToken);
}