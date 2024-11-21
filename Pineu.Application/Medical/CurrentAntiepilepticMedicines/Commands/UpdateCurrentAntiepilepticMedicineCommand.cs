using Pineu.Application.MainDomain.MedicalInformations.Commands;
using Pineu.Domain.Repositories.Medical;

namespace Pineu.Application.Medical.CurrentAntiepilepticMedicines.Commands;

public sealed record UpdateCurrentAntiepilepticMedicineCommand(IEnumerable<CurrentAntiepilepticMedicineDTO> Dtos) : ICommand;

internal class UpdateCurrentAntiepilepticMedicineCommandHandler(ICurrentAntiepilepticMedicineRepository repository)
    : ICommandHandler<UpdateCurrentAntiepilepticMedicineCommand> {
    public async Task<Result> Handle(UpdateCurrentAntiepilepticMedicineCommand request, CancellationToken cancellationToken) {
        if (!request.Dtos.Any())
            return Result.Success();
        var ids = request.Dtos.Select(d => d.Id);
        var pams = await repository.GetAllAsync(ids, cancellationToken);
        if (pams.Count() != request.Dtos.Count())
            return Result.Failure(DomainErrors.PastAntiepilepticMedicine.DoesNotMatch);

        foreach (var item in pams) {
            var dto = request.Dtos.First(d => d.Id == item.Id);
            item.Update(
                int.TryParse(dto.MedicineId, out var userMedicineId) ? userMedicineId : null,
                Guid.TryParse(dto.MedicineId, out var medicineId) ? medicineId : null,
                dto.Amount,
                dto.DateTimeUnitTypeId,
                dto.DurationOfUseTypeId,
                dto.Complications);
        }
        await repository.UpdateRangeAsync(pams, cancellationToken);
        return Result.Success();
    }
}