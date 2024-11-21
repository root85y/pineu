namespace Pineu.Application.MainDomain.Profiles.Commands;

public sealed record UpdateProfileCommand(
      Guid Doctor,
    Guid UserId) : ICommand;
