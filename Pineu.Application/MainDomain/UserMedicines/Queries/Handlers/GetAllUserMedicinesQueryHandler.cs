using Pineu.Application.MainDomain.UserMedicines.Queries.DTOs;

namespace Pineu.Application.MainDomain.UserMedicines.Queries.Handlers
{
    internal class GetAllUserMedicinesQueryHandler(IUserMedicineRepository repository) : IQueryHandler<GetAllUserMedicinesQuery, IEnumerable<GetUserMedicineResponse>>
    {
        public async Task<Result<IEnumerable<GetUserMedicineResponse>>> Handle(GetAllUserMedicinesQuery request, CancellationToken cancellationToken)
        {
            var medicines = await repository.GetAllAsync(request.UserId,
                request.Search, request.MedicineTypes, cancellationToken);

            var res = medicines.Select(m =>
                new GetUserMedicineResponse(m.Id, m.Name, m.Type));
            return res.ToList();
        }
    }
}
