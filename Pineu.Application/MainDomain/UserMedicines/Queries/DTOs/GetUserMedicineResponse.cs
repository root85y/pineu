namespace Pineu.Application.MainDomain.UserMedicines.Queries.DTOs
{
    public sealed record GetUserMedicineResponse(Guid Id, string Name, MedicineType? Type);
}
