namespace Pineu.Application.MainDomain.DefaultMedicines.Queries.DTOs
{
    public sealed record GetDefaultMedicineResponse(string Id, string Name, MedicineType? Type);
}
