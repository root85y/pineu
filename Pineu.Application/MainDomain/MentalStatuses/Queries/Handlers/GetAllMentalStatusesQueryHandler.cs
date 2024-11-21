using Pineu.Application.MainDomain.MentalStatuses.Queries.DTOs;
using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.Seizures.Queries;

namespace Pineu.Application.MainDomain.MentalStatuses.Queries.Handlers {
    internal class GetAllMentalStatusesQueryHandler(IMentalStatusRepository repository, ISender sender)
        : IQueryHandler<GetAllMentalStatusesQuery, PagedResponse<IEnumerable<GetAllMentalStatusesResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetAllMentalStatusesResponse>>>> Handle(GetAllMentalStatusesQuery request, CancellationToken cancellationToken) {
            var mentalStatuses = await repository.GetAllAsync(request.From, request.To, request.Page, request.PageSize, request.UserId, cancellationToken);
            var seizures = await sender.Send(new GetAllSeizuresQuery(request.UserId, request.From, request.To, request.Page, request.PageSize), cancellationToken);

            var res = mentalStatuses.List.Select(ms => new GetAllMentalStatusesResponse(
                ms.Date,
                ms.Value,
                seizures.Value.List.Any(s => DateOnly.FromDateTime(s.SeizureDateTime) == ms.Date)));
            return new PagedResponse<IEnumerable<GetAllMentalStatusesResponse>>(res, mentalStatuses.Count);
        }
    }
}
