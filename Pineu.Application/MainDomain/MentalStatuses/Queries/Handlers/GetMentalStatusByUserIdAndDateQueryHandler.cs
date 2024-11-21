using Pineu.Application.MainDomain.MentalStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.MentalStatuses.Queries.Handlers {
    internal class GetMentalStatusByUserIdAndDateQueryHandler(IMentalStatusRepository repository)
        : IQueryHandler<GetMentalStatusByUserIdAndDateQuery, GetMentalStatusResponse> {
        public async Task<Result<GetMentalStatusResponse>> Handle(GetMentalStatusByUserIdAndDateQuery request, CancellationToken cancellationToken) {
            var mentalS = await repository.GetAsync(request.UserId, request.Date, cancellationToken);
            if (mentalS == null) return Result.Failure<GetMentalStatusResponse>(DomainErrors.MentalStatus.MentalStatusNotFound);

            return new GetMentalStatusResponse(mentalS.Value);
        }
    }
}
