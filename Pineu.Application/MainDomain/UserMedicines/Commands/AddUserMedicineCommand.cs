namespace Pineu.Application.MainDomain.UserMedicines.Commands
{
    public sealed record AddUserMedicineCommand(string Name, MedicineType? Type, Guid UserId) : ICommand<Guid>;
}
