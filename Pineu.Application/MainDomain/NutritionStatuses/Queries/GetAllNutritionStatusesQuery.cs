using Pineu.Application.MainDomain.NutritionStatuses.Queries.DTOs;
using Pineu.Application.MainDomain.Patient.Queries.DTOs;

namespace Pineu.Application.MainDomain.NutritionStatuses.Queries {
    public sealed record GetAllNutritionStatusesQuery(DateTime? From, DateTime? To, int? Page, int? PageSize, Guid UserId)
        : IQuery<PagedResponse<IEnumerable<GetAllNutritionStatusesResponse>>>;
}
