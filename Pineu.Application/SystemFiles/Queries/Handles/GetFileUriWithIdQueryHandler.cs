using Pineu.Application.SystemFiles.Commands.DTOs;
using Pineu.Domain.Repositories.SystemFiles;

namespace Pineu.Application.SystemFiles.Queries.Handles {
    internal class GetFileUriWithIdQueryHandler(ISystemFileRepository repository) : IQueryHandler<GetFileUriWithIdQuery, SystemFileResponse> {
        public async Task<Result<SystemFileResponse>> Handle(GetFileUriWithIdQuery request, CancellationToken cancellationToken) {
            var file = await repository.GetAsync(request.Id, cancellationToken);
            if (file == null) return Result.Failure<SystemFileResponse>(DomainErrors.SystemFile.FileNotFound);

            return new SystemFileResponse(file.FilePath,file.Url);
            //throw new NotImplementedException();
        }
    }
}