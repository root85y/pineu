using Pineu.Application.MainDomain.NutritionStatuses.Queries.DTOs;
using Pineu.Application.MainDomain.Patient.Queries.DTOs;

namespace Pineu.Application.MainDomain.Patient.Queries {
    public sealed record GetAllNutritionStatusesForPatientQuery(DateTime? From, DateTime? To, Guid UserId)
        : IQuery<PagedResponse<IEnumerable<GetAllNutritionStatusesForPatientResponse>>>;
}
