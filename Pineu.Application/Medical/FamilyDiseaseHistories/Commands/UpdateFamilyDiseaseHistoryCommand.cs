using Pineu.Application.MainDomain.MedicalInformations.Commands;
using Pineu.Domain.Repositories.Medical;

namespace Pineu.Application.Medical.FamilyDiseaseHistories.Commands;

public sealed record UpdateFamilyDiseaseHistoryCommand(IEnumerable<FamilyDiseaseHistoryDTO> Dtos) : ICommand;

internal class UpdateFamilyDiseaseHistoryCommandHandler(IFamilyDiseaseHistoryRepository repository)
    : ICommandHandler<UpdateFamilyDiseaseHistoryCommand> {
    public async Task<Result> Handle(UpdateFamilyDiseaseHistoryCommand request, CancellationToken cancellationToken) {
        if (!request.Dtos.Any())
            return Result.Success();
        var ids = request.Dtos.Select(d => d.Id);
        var pams = await repository.GetAllAsync(ids, cancellationToken);
        if (pams.Count() != request.Dtos.Count())
            return Result.Failure(DomainErrors.PastAntiepilepticMedicine.DoesNotMatch);

        foreach (var item in pams) {
            var dto = request.Dtos.First(d => d.Id == item.Id);
            item.Update(
                dto.FamilyDiseaseHistoryTypeId,
                dto.Name, 
                dto.Relationship);
        }
        await repository.UpdateRangeAsync(pams, cancellationToken);
        return Result.Success();
    }
}