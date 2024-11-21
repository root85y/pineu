using Pineu.Application.MainDomain.UserMedicines.Queries.DTOs;

namespace Pineu.Application.MainDomain.UserMedicines.Queries
{
    public sealed record GetAllUserMedicinesQuery(Guid UserId, string? Search, IEnumerable<MedicineType>? MedicineTypes) 
        : IQuery<IEnumerable<GetUserMedicineResponse>>;
}
