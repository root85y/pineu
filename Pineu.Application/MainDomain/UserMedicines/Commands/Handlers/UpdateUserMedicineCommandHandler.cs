namespace Pineu.Application.MainDomain.UserMedicines.Commands.Handlers
{
    internal class UpdateUserMedicineCommandHandler(IUserMedicineRepository repository) : ICommandHandler<UpdateUserMedicineCommand>
    {
        public async Task<Result> Handle(UpdateUserMedicineCommand request, CancellationToken cancellationToken)
        {
            var medicine = await repository.GetAsync(request.Id, cancellationToken);
            if (medicine == null) return Result.Failure(DomainErrors.UserMedicine.UserMedicineNotFound);

            medicine.Update(request.Name, request.Type);
            await repository.UpdateAsync(medicine, cancellationToken);

            return Result.Success();
        }
    }
}
