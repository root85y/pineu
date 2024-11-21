using Pineu.Application.MainDomain.UserMedicines.Queries.DTOs;

namespace Pineu.Application.MainDomain.UserMedicines.Queries.Handlers
{
    internal class GetUserMedicineByIdQueryHandler(IUserMedicineRepository repository) : IQueryHandler<GetUserMedicineByIdQuery, GetUserMedicineResponse>
    {
        public async Task<Result<GetUserMedicineResponse>> Handle(GetUserMedicineByIdQuery request, CancellationToken cancellationToken)
        {
            var medicine = await repository.GetAsync(request.Id, cancellationToken);
            if (medicine == null) return Result.Failure<GetUserMedicineResponse>(DomainErrors.UserMedicine.UserMedicineNotFound);

            return new GetUserMedicineResponse(medicine.Id, medicine.Name, medicine.Type);
        }
    }
}
