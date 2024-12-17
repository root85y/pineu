﻿using Pineu.Application.MainDomain.MedicalInformations.Commands;
using Pineu.Domain.Repositories.Medical;

namespace Pineu.Application.Medical.PastAntiepilepticMedicines.Commands;

public sealed record UpdatePastAntiepilepticMedicineCommand(IEnumerable<PastAntiepilepticMedicineDTO> Dtos) : ICommand;

internal class UpdatePastAntiepilepticMedicineCommandHandler(IPastAntiepilepticMedicineRepository repository)
    : ICommandHandler<UpdatePastAntiepilepticMedicineCommand> {
    public async Task<Result> Handle(UpdatePastAntiepilepticMedicineCommand request, CancellationToken cancellationToken) {
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
                dto.StopDate.HasValue ? DateOnly.FromDateTime(dto.StopDate.Value) : null,
                dto.ReasonOfStop);
        }
        await repository.UpdateRangeAsync(pams, cancellationToken);
        return Result.Success();
    }
}