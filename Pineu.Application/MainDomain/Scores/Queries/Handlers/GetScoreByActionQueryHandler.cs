using Pineu.Application.MainDomain.Scores.Queries.DTOs;

namespace Pineu.Application.MainDomain.Scores.Queries.Handlers {
    internal class GetScoreByActionQueryHandler(IScoreRepository repository) : IQueryHandler<GetScoreByActionQuery, GetScoreResponse> {
        public async Task<Result<GetScoreResponse>> Handle(GetScoreByActionQuery request, CancellationToken cancellationToken) {
            var score = await repository.GetAsync(request.Action, cancellationToken);
            if (score == null) return Result.Failure<GetScoreResponse>(DomainErrors.Score.ScoreNotFound);

            return new GetScoreResponse(score.Action, score.ScoreCount);
        }
    }
}
