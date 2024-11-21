using Pineu.Application.MainDomain.MedicalInformations.Commands;
using Pineu.Domain.Entities.Medical;
using Pineu.Domain.Repositories.Medical;

namespace Pineu.Application.Medical.PastAntiepilepticMedicines.Commands;

public sealed record AddPastAntiepilepticMedicineCommand(IEnumerable<PastAntiepilepticMedicineDTO> Dtos, Guid MedicalInfoId) : ICommand;

internal class AddPastAntiepilepticMedicineCommandHandler(IPastAntiepilepticMedicineRepository repository) 
    : ICommandHandler<AddPastAntiepilepticMedicineCommand> {
    public async Task<Result> Handle(AddPastAntiepilepticMedicineCommand request, CancellationToken cancellationToken)
    {
        if (!request.Dtos.Any())
            return Result.Success();
        var pams = request.Dtos.Select(pam =>
            PastAntiepilepticMedicine.Create(
                Guid.NewGuid(),
                int.TryParse(pam.MedicineId, out var userMedicineId) ? userMedicineId : null,
                Guid.TryParse(pam.MedicineId, out var medicineId) ? medicineId : null,
                pam.Amount,
                pam.DateTimeUnitTypeId,
                pam.DurationOfUseTypeId,
                pam.StopDate.HasValue ? DateOnly.FromDateTime(pam.StopDate.Value) : null,
                pam.ReasonOfStop,
                request.MedicalInfoId)
        );
        await repository.AddRangeAsync(pams, cancellationToken);
        return Result.Success();
    }
}
