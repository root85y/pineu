using Pineu.Application.MainDomain.NutritionStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.NutritionStatuses.Queries.Handlers {
    internal class GetNutritionStatusesChartQueryHandler(INutritionStatusRepository repository)
        : IQueryHandler<GetNutritionStatusesChartQuery, GetNutritionStatusChartResponse> {
        public async Task<Result<GetNutritionStatusChartResponse>> Handle(GetNutritionStatusesChartQuery request, CancellationToken cancellationToken) {
            var nutritionSs = await repository.GetAllAsync(request.From, request.To, null, null, request.UserId, cancellationToken);

            var foodTypes = new List<string> {
                "Grains",
                "SugarAndFat",
                "Protein",
                "Vegetables",
                "Fruits",
                "Dairy",
                "Beverages"
            };
            var values = new List<int> {
                GetSum(nutritionSs.List, IngredientCategory.Grains),
                GetSum(nutritionSs.List, IngredientCategory.SugarAndFat),
                GetSum(nutritionSs.List, IngredientCategory.Protein),
                GetSum(nutritionSs.List, IngredientCategory.Vegetables),
                GetSum(nutritionSs.List, IngredientCategory.Fruits),
                GetSum(nutritionSs.List, IngredientCategory.Dairy),
                GetSum(nutritionSs.List, IngredientCategory.Beverages),
            };
            return new GetNutritionStatusChartResponse(foodTypes, values);
        }

        private int GetSum(IEnumerable<NutritionStatus> list, IngredientCategory category) =>
            list.Sum(ns => ns.Ingredients.Count(i => i.Category == category)) +
            list.Sum(ns => ns.UserIngredients.Count(i => i.Category == category));
    }
}
