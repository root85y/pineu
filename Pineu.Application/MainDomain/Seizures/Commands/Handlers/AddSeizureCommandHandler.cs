using Pineu.Application.MainDomain.Profiles.Commands;

namespace Pineu.Application.MainDomain.Seizures.Commands.Handlers {
    internal class AddSeizureCommandHandler(ISeizureRepository repository, ISender sender) : ICommandHandler<AddSeizureCommand, Guid> {
        public async Task<Result<Guid>> Handle(AddSeizureCommand request, CancellationToken cancellationToken) {
            if (await repository.HasSubmittedTooMany(cancellationToken))
                return Result.Failure<Guid>(DomainErrors.Seizure.LimitReached);

            var seizure = Seizure.Create(
                id: Guid.NewGuid(),
                userId: request.UserId,
                seizureDateTime: request.SeizureDateTime,
                seizureDuration: request.SeizureDuration,
                attackTypeList: request.AttackTypeList,
                injuryList: request.InjuryList,
                severityOfInjury: request.SeverityOfInjury,
                mentalStatusBeforeSeizure: request.MentalStatusBeforeSeizure,
                amountOfPhysicalStatusBeforeSeizure: request.AmountOfPhysicalStatusBeforeSeizure,
                generalStatusBeforeSeizure: request.GeneralStatusBeforeSeizure,
                sleepQualityAtTheNightBeforeSeizure: request.SleepQualityAtTheNightBeforeSeizure,
                activityAtSeizureTime: request.ActivityAtSeizureTime,
                foodBeforeSeizure: request.FoodBeforeSeizure,
                amountOfFoodBeforeSeizure: request.AmountOfFoodBeforeSeizure,
                smokingConsumption: request.SmokingConsumption,
                alcoholConsumption: request.AlcoholConsumption,
                mentalStatusAfterSeizure: request.MentalStatusAfterSeizure,
                generalStatusAfterSeizure: request.GeneralStatusAfterSeizure);
            await repository.AddAsync(seizure, cancellationToken);

            await sender.Send(new UpdateProfileScoreCommand(ScoreAction.AddSeizure, request.UserId, null), cancellationToken);
            return seizure.Id;
        }
    }
}
