using Pineu.Domain.Repositories.Medical;

namespace Pineu.Application.Medical.PastAntiepilepticMedicines.Commands;

public sealed record DeletePastAntiepilepticMedicineCommand(IEnumerable<Guid> Ids): ICommand;

internal class DeletePastAntiepilepticMedicineCommandHandler(IPastAntiepilepticMedicineRepository repository)
    : ICommandHandler<DeletePastAntiepilepticMedicineCommand> {
    public async Task<Result> Handle(DeletePastAntiepilepticMedicineCommand request, CancellationToken cancellationToken) {
        if (!request.Ids.Any())
            return Result.Success();
        var pams = await repository.GetAllAsync(request.Ids, cancellationToken);
        if (pams.Count() != request.Ids.Count())
            return Result.Failure(DomainErrors.PastAntiepilepticMedicine.DoesNotMatch);

        await repository.DeleteRangeAsync(pams, cancellationToken);
        return Result.Success();
    }
}