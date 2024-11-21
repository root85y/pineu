using Pineu.Application.MainDomain.Patient.Queries;
using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.Seizures.Queries;
using Pineu.Application.MainDomain.WorkoutStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.WorkoutStatuses.Queries.Handlers {
    internal class GetAllWorkoutStatusesForPatientQueryHandler(IWorkoutStatusRepository repository, ISender sender)
        : IQueryHandler<GetAllWorkoutStatusesForPatientQuery, PagedResponse<IEnumerable<GetAllWorkoutStatusesForPatientResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetAllWorkoutStatusesForPatientResponse>>>> Handle(GetAllWorkoutStatusesForPatientQuery request, CancellationToken cancellationToken) {
            var workoutStatuses = await repository.GetAllForPatientAsync(request.From, request.To, request.UserId,
                cancellationToken);

            var res = workoutStatuses.List.Select(ms => new GetAllWorkoutStatusesForPatientResponse(
                ms.Date,
                ms.Value
                ));
            return new PagedResponse<IEnumerable<GetAllWorkoutStatusesForPatientResponse>>(res, workoutStatuses.Count);
        }
    }
}
