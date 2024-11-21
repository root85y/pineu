using Pineu.Application.SystemFiles.Commands.DTOs;

namespace Pineu.Application.SystemFiles.Commands;
public sealed record AddSystemFileCommand(byte[] File, string FullPath, string FileNameAndType) : ICommand<SystemFileResponse>;
