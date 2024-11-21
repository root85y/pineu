using Pineu.Application.MainDomain.DefaultMedicines.Queries.DTOs;

namespace Pineu.Application.MainDomain.DefaultMedicines.Queries.Handlers
{
    internal class GetAllDefaultMedicinesQueryHandler(IDefaultMedicineRepository repository) : IQueryHandler<GetAllDefaultMedicinesQuery, IEnumerable<GetDefaultMedicineResponse>>
    {
        public async Task<Result<IEnumerable<GetDefaultMedicineResponse>>> Handle(GetAllDefaultMedicinesQuery request, CancellationToken cancellationToken)
        {
            var medicines = await repository.GetAllAsync(request.MedicineTypes,
                 request.Search, cancellationToken);
            return medicines.Select(m => new GetDefaultMedicineResponse(m.Id.ToString(), m.Name, m.Type)).ToList();
        }
    }
}
