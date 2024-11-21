using Pineu.Application.MainDomain.SleepStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.SleepStatuses.Queries.Handlers {
    internal class GetSleepStatusByUserIdQueryHandler(ISleepStatusRepository repository) : IQueryHandler<GetSleepStatusByUserIdQuery, GetSleepStatusResponse> {
        public async Task<Result<GetSleepStatusResponse>> Handle(GetSleepStatusByUserIdQuery request, CancellationToken cancellationToken) {
            var sleepS = await repository.GetAsync(request.UserId, request.Date, cancellationToken);
            if (sleepS == null) return Result.Failure<GetSleepStatusResponse>(DomainErrors.SleepStatus.SleepStatusNotFound);

            return new GetSleepStatusResponse(sleepS.Value);
        }
    }
}
