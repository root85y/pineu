using Pineu.Application.MainDomain.MedicalInformations.Commands;
using Pineu.Domain.Entities.Medical;
using Pineu.Domain.Repositories.Medical;

namespace Pineu.Application.Medical.FamilyDiseaseHistories.Commands;

public sealed record AddFamilyDiseaseHistoryCommand(IEnumerable<FamilyDiseaseHistoryDTO> Dtos, Guid MedicalInfoId) : ICommand;

internal class AddFamilyDiseaseHistoryCommandHandler(IFamilyDiseaseHistoryRepository repository) 
    : ICommandHandler<AddFamilyDiseaseHistoryCommand> {
    public async Task<Result> Handle(AddFamilyDiseaseHistoryCommand request, CancellationToken cancellationToken)
    {
        if (!request.Dtos.Any())
            return Result.Success();
        var pams = request.Dtos.Select(pam =>
            FamilyDiseaseHistory.Create(
                Guid.NewGuid(),
                pam.FamilyDiseaseHistoryTypeId,
                pam.Name,
                pam.Relationship,
                request.MedicalInfoId)
        );
        await repository.AddRangeAsync(pams, cancellationToken);
        return Result.Success();
    }
}
