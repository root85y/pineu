using Pineu.Application.MainDomain.NutritionStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.NutritionStatuses.Queries {
    public sealed record GetNutritionStatusesChartQuery(Guid UserId, DateTime? From, DateTime? To)
        : IQuery<GetNutritionStatusChartResponse>;
}
