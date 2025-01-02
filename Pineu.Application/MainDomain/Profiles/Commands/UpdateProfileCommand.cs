namespace Pineu.Application.MainDomain.Profiles.Commands;

public sealed record UpdateProfileCommand(
      Guid Doctor,
      string Status,
    Guid UserId) : ICommand;
