using Pineu.Application.MainDomain.MedicalInformations.Commands;
using Pineu.Domain.Entities.Medical;
using Pineu.Domain.Repositories.Medical;

namespace Pineu.Application.Medical.CurrentAntiepilepticMedicines.Commands;

public sealed record AddCurrentAntiepilepticMedicineCommand(IEnumerable<CurrentAntiepilepticMedicineDTO> Dtos, Guid MedicalInfoId) : ICommand;

internal class AddCurrentAntiepilepticMedicineCommandHandler(ICurrentAntiepilepticMedicineRepository repository) 
    : ICommandHandler<AddCurrentAntiepilepticMedicineCommand> {
    public async Task<Result> Handle(AddCurrentAntiepilepticMedicineCommand request, CancellationToken cancellationToken)
    {
        if (!request.Dtos.Any())
            return Result.Success();
        var pams = request.Dtos.Select(pam =>
            CurrentAntiepilepticMedicine.Create(
                Guid.NewGuid(),
                int.TryParse(pam.MedicineId, out var userMedicineId) ? userMedicineId : null,
                Guid.TryParse(pam.MedicineId, out var medicineId) ? medicineId : null,
                pam.Amount,
                pam.DateTimeUnitTypeId,
                pam.DurationOfUseTypeId,
                pam.Complications,
                request.MedicalInfoId)
        );
        await repository.AddRangeAsync(pams, cancellationToken);
        return Result.Success();
    }
}
