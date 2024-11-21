using Pineu.Domain.Repositories.SystemFiles;

namespace Pineu.Application.SystemFiles.Commands.Handlers;
internal class RemoveSystemFileCommandHandler(ISystemFileRepository repository) : ICommandHandler<RemoveSystemFileCommand> {
    public async Task<Result> Handle(RemoveSystemFileCommand request, CancellationToken cancellationToken) {
        var file = await repository.GetAsync(request.Id, cancellationToken);
        if (file == null) return Result.Failure(DomainErrors.SystemFile.FileNotFound);

        await repository.RemoveAsync(file, cancellationToken);

        if (File.Exists(file.FilePath))
            File.Delete(file.FilePath);

        return Result.Success();
    }
}
