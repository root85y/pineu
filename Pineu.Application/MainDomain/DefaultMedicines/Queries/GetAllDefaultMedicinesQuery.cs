using Pineu.Application.MainDomain.DefaultMedicines.Queries.DTOs;

namespace Pineu.Application.MainDomain.DefaultMedicines.Queries
{
    public sealed record GetAllDefaultMedicinesQuery(IEnumerable<MedicineType>? MedicineTypes, string? Search)
        : IQuery<IEnumerable<GetDefaultMedicineResponse>>;
}
