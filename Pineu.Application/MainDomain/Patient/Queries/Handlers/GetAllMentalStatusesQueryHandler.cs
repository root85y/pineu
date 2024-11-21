using Pineu.Application.MainDomain.MentalStatuses.Queries;
using Pineu.Application.MainDomain.MentalStatuses.Queries.DTOs;
using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.Seizures.Queries;

namespace Pineu.Application.MainDomain.Patient.Queries.Handlers {
    internal class GetAllMentalStatusesForPatientQueryHandler(IMentalStatusRepository repository, ISender sender)
        : IQueryHandler<GetAllMentalStatusesForPatientQuery, PagedResponse<IEnumerable<GetAllMentalStatusesForPatientResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetAllMentalStatusesForPatientResponse>>>> Handle(GetAllMentalStatusesForPatientQuery request, CancellationToken cancellationToken) {
            var mentalStatuses = await repository.GetAllForPatientAsync(request.From, request.To, request.UserId, cancellationToken);

            var res = mentalStatuses.List.Select(ms => new GetAllMentalStatusesForPatientResponse(
                ms.Date,
                ms.Value
                ));
            return new PagedResponse<IEnumerable<GetAllMentalStatusesForPatientResponse>>(res, mentalStatuses.Count);
        }
    }
}
