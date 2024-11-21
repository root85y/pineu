namespace Pineu.Application.MainDomain.NutritionStatuses.Queries.DTOs {
    public sealed record GetNutritionStatusChartResponse(IEnumerable<string> FoodTypes, IEnumerable<int> Values);
}
