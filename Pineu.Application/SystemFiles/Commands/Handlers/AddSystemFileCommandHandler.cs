using Pineu.Application.SystemFiles.Commands.DTOs;
using Pineu.Domain.Entities.SystemFiles;
using Pineu.Domain.Repositories.SystemFiles;

namespace Pineu.Application.SystemFiles.Commands.Handlers;
internal sealed class AddSystemFileCommandHandler(
    ISystemFileRepository fileRepository)
    : ICommandHandler<AddSystemFileCommand, SystemFileResponse> {
    async Task<Result<SystemFileResponse>> IRequestHandler<AddSystemFileCommand, Result<SystemFileResponse>>.Handle(
        AddSystemFileCommand request, CancellationToken cancellationToken) {

        var id = Guid.NewGuid();
        var fileName = id + request.FileNameAndType;
        var filePathAndName = Path.Combine(request.FullPath, fileName);

        if (request.File.Length > 1 * 1024 * 1024 * 1024)
            return Result.Failure<SystemFileResponse>(DomainErrors.SystemFile.FileIsLarge);

        if (!Directory.Exists(request.FullPath))
            Directory.CreateDirectory(request.FullPath);

        if (request.File.Length > 0)
            await File.WriteAllBytesAsync(filePathAndName, request.File, cancellationToken);
        else
            return Result.Failure<SystemFileResponse>(DomainErrors.SystemFile.FileIsEmpty);

        var res = SystemFile.Create(id, filePathAndName);

        //await fileRepository.AddAsync(res.Value, cancellationToken);

        return new SystemFileResponse(res.Value.FilePath, res.Value.Url);
    }
}