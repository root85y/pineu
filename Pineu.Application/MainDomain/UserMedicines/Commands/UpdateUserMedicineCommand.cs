namespace Pineu.Application.MainDomain.UserMedicines.Commands
{
    public sealed record UpdateUserMedicineCommand(Guid Id, string Name, MedicineType? Type)
        : ICommand;
}
