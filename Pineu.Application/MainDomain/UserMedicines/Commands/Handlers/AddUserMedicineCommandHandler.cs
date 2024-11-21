namespace Pineu.Application.MainDomain.UserMedicines.Commands.Handlers
{
    internal class AddUserMedicineCommandHandler(IUserMedicineRepository repository) 
        : ICommandHandler<AddUserMedicineCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(AddUserMedicineCommand request, CancellationToken cancellationToken)
        {
            var medicine = UserMedicine.Create(Guid.NewGuid(), request.Name, request.Type, request.UserId);

            await repository.AddAsync(medicine, cancellationToken);
            return medicine.Id;
        }
    }
}
