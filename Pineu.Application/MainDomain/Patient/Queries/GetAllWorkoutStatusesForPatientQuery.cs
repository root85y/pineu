using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.WorkoutStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.Patient.Queries {
    public sealed record GetAllWorkoutStatusesForPatientQuery(DateTime? From, DateTime? To, Guid UserId)
        : IQuery<PagedResponse<IEnumerable<GetAllWorkoutStatusesForPatientResponse>>>;
}
