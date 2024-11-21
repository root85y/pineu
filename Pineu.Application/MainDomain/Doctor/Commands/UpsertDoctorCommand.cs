namespace Pineu.Application.MainDomain.Profiles.Commands
{
    public sealed record UpsertDoctorCommand(
        Doctor doctor ) : ICommand;
}