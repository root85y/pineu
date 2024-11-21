using Pineu.Application.MainDomain.ScoreLogs.Queries.DTOs;

namespace Pineu.Application.MainDomain.ScoreLogs.Queries.Handlers {
    internal class GetUsersScoreSummeryQueryHandler(IScoreLogRepository repository, IProfileRepository profileRepository) : IQueryHandler<GetUsersScoreSummeryQuery, GetUsersScoreSummeryResponse> {
        public async Task<Result<GetUsersScoreSummeryResponse>> Handle(GetUsersScoreSummeryQuery request, CancellationToken cancellationToken) {
            var scoreLogs = await repository.GetAllAsync(null, null, null, null, request.UserId, null, cancellationToken);
            var profile = await profileRepository.GetAsync(request.UserId, cancellationToken);
            if (profile == null) return Result.Failure<GetUsersScoreSummeryResponse>(DomainErrors.Profile.ProfileNotFound);

            var positiveScores = scoreLogs.List.Where(sl => sl.Change >= 0).Sum(sl => sl.Change);
            var negativeScores = scoreLogs.List.Where(sl => sl.Change < 0).Sum(sl => sl.Change);
            return new GetUsersScoreSummeryResponse(profile.Score, positiveScores, Math.Abs(negativeScores));
        }
    }
}
