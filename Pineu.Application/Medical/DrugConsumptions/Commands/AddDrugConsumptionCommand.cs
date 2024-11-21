using Pineu.Application.MainDomain.MedicalInformations.Commands;
using Pineu.Domain.Entities.Medical;
using Pineu.Domain.Repositories.Medical;

namespace Pineu.Application.Medical.DrugConsumptions.Commands;

public sealed record AddDrugConsumptionCommand(IEnumerable<DrugConsumptionDTO> Dtos, Guid MedicalInfoId) : ICommand;

internal class AddDrugConsumptionCommandHandler(IDrugConsumptionRepository repository) 
    : ICommandHandler<AddDrugConsumptionCommand> {
    public async Task<Result> Handle(AddDrugConsumptionCommand request, CancellationToken cancellationToken)
    {
        if (!request.Dtos.Any())
            return Result.Success();
        var pams = request.Dtos.Select(pam =>
            DrugConsumption.Create(
                Guid.NewGuid(),
                pam.DrugTypeId,
                pam.DailyAmount,
                pam.DrugConsumptionDuration,
                pam.DateTimeUnitTypeId,
                request.MedicalInfoId)
        );
        await repository.AddRangeAsync(pams, cancellationToken);
        return Result.Success();
    }
}
