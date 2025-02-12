namespace Pineu.Application.MainDomain.Profiles.Commands
{
    public sealed record UpsertDoctorCommand(
        Pineu.Domain.Entities.MainDomain.Doctor doctor ) : ICommand;
}