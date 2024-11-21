using Pineu.Application.MainDomain.MentalStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.MentalStatuses.Queries.Handlers {
    internal class GetMentalStatusesChartQueryHandler(IMentalStatusRepository repository)
        : IQueryHandler<GetMentalStatusesChartQuery, GetMentalStatusChartResponse> {
        public async Task<Result<GetMentalStatusChartResponse>> Handle(GetMentalStatusesChartQuery request, CancellationToken cancellationToken) {
            var mentalSs = await repository.GetAllAsync(request.From, request.To, null, null, request.UserId, cancellationToken);

            var mentalList = new List<MentalStatusEnum>() {
                MentalStatusEnum.Normal,
                MentalStatusEnum.Happy,
                MentalStatusEnum.Sad,
                MentalStatusEnum.Fear,
                MentalStatusEnum.Shame,
                MentalStatusEnum.Angry,
                MentalStatusEnum.Thrill,
                MentalStatusEnum.Worry
            };
            var values = new List<int> {
                mentalSs.List.Count(ms => ms.Value.Contains(MentalStatusEnum.Normal)),
                mentalSs.List.Count(ms => ms.Value.Contains(MentalStatusEnum.Happy)),
                mentalSs.List.Count(ms => ms.Value.Contains(MentalStatusEnum.Sad)),
                mentalSs.List.Count(ms => ms.Value.Contains(MentalStatusEnum.Fear)),
                mentalSs.List.Count(ms => ms.Value.Contains(MentalStatusEnum.Shame)),
                mentalSs.List.Count(ms => ms.Value.Contains(MentalStatusEnum.Angry)),
                mentalSs.List.Count(ms => ms.Value.Contains(MentalStatusEnum.Thrill)),
                mentalSs.List.Count(ms => ms.Value.Contains(MentalStatusEnum.Worry)),
            };
            return new GetMentalStatusChartResponse(mentalList, values);
        }
    }
}
