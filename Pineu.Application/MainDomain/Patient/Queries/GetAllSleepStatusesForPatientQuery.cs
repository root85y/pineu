using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.SleepStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.Patient.Queries;
public sealed record GetAllSleepStatusesForPatiantQuery(
    DateTime? From, 
    DateTime? To, 
    Guid UserId
    )
    : IQuery<PagedResponse<IEnumerable<GetAllSleepStatForPatientResponse>>>;
