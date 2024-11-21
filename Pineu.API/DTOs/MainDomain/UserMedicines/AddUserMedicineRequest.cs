namespace Pineu.API.DTOs.MainDomain.UserMedicines
{
    public sealed record AddUserMedicineRequest(string Name, MedicineType? Type);
}
