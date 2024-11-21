using Pineu.Application.SystemFiles.Commands.DTOs;

namespace Pineu.Application.SystemFiles.Queries {
    public sealed record GetFileUriWithIdQuery(Guid Id) : IQuery<SystemFileResponse>;
}
