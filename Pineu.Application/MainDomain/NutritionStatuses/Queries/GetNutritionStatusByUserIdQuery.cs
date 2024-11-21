using Pineu.Application.MainDomain.NutritionStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.NutritionStatuses.Queries {
    public sealed record GetNutritionStatusByUserIdQuery(Guid UserId, DateTime? Date) : IQuery<GetNutritionStatusResponse>;
}
