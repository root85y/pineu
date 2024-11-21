namespace Pineu.Application.MainDomain.Profiles.Commands
{
    public sealed record UpsertProfileCommand(
        string? FullName,
        Gender? Gender,
        DateTime? Birthdate,
        MaritalStatus? MaritalStatus,
        string? UserType,
        string? PhoneNumber,
        Guid? Doctor,
        string Status,
        Guid UserId ) : ICommand;
}
