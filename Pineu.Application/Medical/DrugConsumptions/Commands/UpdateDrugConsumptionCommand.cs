using Pineu.Application.MainDomain.MedicalInformations.Commands;
using Pineu.Domain.Repositories.Medical;

namespace Pineu.Application.Medical.DrugConsumptions.Commands;

public sealed record UpdateDrugConsumptionCommand(IEnumerable<DrugConsumptionDTO> Dtos) : ICommand;

internal class UpdateDrugConsumptionCommandHandler(IDrugConsumptionRepository repository)
    : ICommandHandler<UpdateDrugConsumptionCommand> {
    public async Task<Result> Handle(UpdateDrugConsumptionCommand request, CancellationToken cancellationToken) {
        if (!request.Dtos.Any())
            return Result.Success();
        var ids = request.Dtos.Select(d => d.Id);
        var pams = await repository.GetAllAsync(ids, cancellationToken);
        if (pams.Count() != request.Dtos.Count())
            return Result.Failure(DomainErrors.PastAntiepilepticMedicine.DoesNotMatch);

        foreach (var item in pams) {
            var dto = request.Dtos.First(d => d.Id == item.Id);
            item.Update(
                dto.DrugTypeId,
                dto.DailyAmount,
                dto.DrugConsumptionDuration,
                dto.DateTimeUnitTypeId);
        }
        await repository.UpdateRangeAsync(pams, cancellationToken);
        return Result.Success();
    }
}