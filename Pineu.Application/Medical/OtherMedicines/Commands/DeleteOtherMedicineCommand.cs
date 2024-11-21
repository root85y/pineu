using Pineu.Domain.Repositories.Medical;

namespace Pineu.Application.Medical.OtherMedicines.Commands;

public sealed record DeleteOtherMedicineCommand(IEnumerable<Guid> Ids): ICommand;

internal class DeleteOtherMedicineCommandHandler(IOtherMedicineRepository repository)
    : ICommandHandler<DeleteOtherMedicineCommand> {
    public async Task<Result> Handle(DeleteOtherMedicineCommand request, CancellationToken cancellationToken) {
        if (!request.Ids.Any())
            return Result.Success();
        var pams = await repository.GetAllAsync(request.Ids, cancellationToken);
        if (pams.Count() != request.Ids.Count())
            return Result.Failure(DomainErrors.PastAntiepilepticMedicine.DoesNotMatch);

        await repository.DeleteRangeAsync(pams, cancellationToken);
        return Result.Success();
    }
}