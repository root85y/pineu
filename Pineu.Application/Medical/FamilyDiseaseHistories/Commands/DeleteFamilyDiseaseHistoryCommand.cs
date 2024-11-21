using Pineu.Domain.Repositories.Medical;

namespace Pineu.Application.Medical.FamilyDiseaseHistories.Commands;

public sealed record DeleteFamilyDiseaseHistoryCommand(IEnumerable<Guid> Ids): ICommand;

internal class DeleteFamilyDiseaseHistoryCommandHandler(IFamilyDiseaseHistoryRepository repository)
    : ICommandHandler<DeleteFamilyDiseaseHistoryCommand> {
    public async Task<Result> Handle(DeleteFamilyDiseaseHistoryCommand request, CancellationToken cancellationToken) {
        if (!request.Ids.Any())
            return Result.Success();
        var pams = await repository.GetAllAsync(request.Ids, cancellationToken);
        if (pams.Count() != request.Ids.Count())
            return Result.Failure(DomainErrors.PastAntiepilepticMedicine.DoesNotMatch);

        await repository.DeleteRangeAsync(pams, cancellationToken);
        return Result.Success();
    }
}