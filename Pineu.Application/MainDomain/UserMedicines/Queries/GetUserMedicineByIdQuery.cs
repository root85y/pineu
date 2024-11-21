using Pineu.Application.MainDomain.UserMedicines.Queries.DTOs;

namespace Pineu.Application.MainDomain.UserMedicines.Queries
{
    public sealed record GetUserMedicineByIdQuery(Guid Id) : IQuery<GetUserMedicineResponse>;
}
