using Pineu.Domain.Repositories.Medical;

namespace Pineu.Application.Medical.DrugConsumptions.Commands;

public sealed record DeleteDrugConsumptionCommand(IEnumerable<Guid> Ids): ICommand;

internal class DeleteDrugConsumptionCommandHandler(IDrugConsumptionRepository repository)
    : ICommandHandler<DeleteDrugConsumptionCommand> {
    public async Task<Result> Handle(DeleteDrugConsumptionCommand request, CancellationToken cancellationToken) {
        if (!request.Ids.Any())
            return Result.Success();
        var pams = await repository.GetAllAsync(request.Ids, cancellationToken);
        if (pams.Count() != request.Ids.Count())
            return Result.Failure(DomainErrors.PastAntiepilepticMedicine.DoesNotMatch);

        await repository.DeleteRangeAsync(pams, cancellationToken);
        return Result.Success();
    }
}