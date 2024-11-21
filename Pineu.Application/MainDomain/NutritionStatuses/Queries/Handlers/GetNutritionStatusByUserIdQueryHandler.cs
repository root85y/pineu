using Pineu.Application.MainDomain.NutritionStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.NutritionStatuses.Queries.Handlers {
    internal class GetNutritionStatusByUserIdQueryHandler(INutritionStatusRepository repository)
        : IQueryHandler<GetNutritionStatusByUserIdQuery, GetNutritionStatusResponse> {
        public async Task<Result<GetNutritionStatusResponse>> Handle(GetNutritionStatusByUserIdQuery request, CancellationToken cancellationToken) {
            var nutritionS = await repository.GetAsync(request.UserId, request.Date, cancellationToken);
            if (nutritionS == null) return Result.Failure<GetNutritionStatusResponse>(DomainErrors.NutritionStatus.NutritionStatusNotFound);

            return new GetNutritionStatusResponse(
                nutritionS.Ingredients.Select(i =>
                    new DefaultIngredientObject(i.Id.ToString(), new Label(i.FarsiLabel, i.EnglishLabel), i.Category)),
                nutritionS.UserIngredients.Select(ui => 
                    new UserIngredientObject(ui.Id.ToString(), ui.Name, ui.Category)
                ));
        }
    }
}
