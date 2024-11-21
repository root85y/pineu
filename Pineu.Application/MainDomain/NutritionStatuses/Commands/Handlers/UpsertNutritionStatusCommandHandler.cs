using Pineu.Application.MainDomain.Profiles.Commands;

namespace Pineu.Application.MainDomain.NutritionStatuses.Commands.Handlers {
    internal class UpsertNutritionStatusCommandHandler(
        INutritionStatusRepository repository, ISender sender, IDefaultIngredientRepository defaultIngredientRepository,
        IUserIngredientRepository userIngredientRepository)
        : ICommandHandler<UpsertNutritionStatusCommand> {
        public async Task<Result> Handle(UpsertNutritionStatusCommand request, CancellationToken cancellationToken) {
            var nutritionS = await repository.GetAsync(request.UserId, request.Date, cancellationToken);
            var defaultIngredients = await defaultIngredientRepository.GetAllAsync(
                null, null, request.DefaultIngredients, cancellationToken);
            var userIngredients = await userIngredientRepository.GetAllAsync(request.UserId, null,
                null, request.UserIngredients, cancellationToken);
            if (nutritionS == null) {
                nutritionS = NutritionStatus.Create(Guid.NewGuid(), defaultIngredients, userIngredients,
                    DateOnly.FromDateTime(request.Date), request.UserId);
                await repository.AddAsync(nutritionS, cancellationToken);
                await sender.Send(new UpdateProfileScoreCommand(ScoreAction.AddNutritionStatus, request.UserId, null), cancellationToken);
            } else {
                nutritionS.Update(defaultIngredients, userIngredients);
                await repository.UpdateAsync(nutritionS, cancellationToken);
            }
            return Result.Success();
        }
    }
}
