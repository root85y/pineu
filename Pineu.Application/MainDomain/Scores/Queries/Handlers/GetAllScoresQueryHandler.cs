using Pineu.Application.MainDomain.Scores.Queries.DTOs;

namespace Pineu.Application.MainDomain.Scores.Queries.Handlers {
    internal class GetAllScoresQueryHandler(IScoreRepository repository)
        : IQueryHandler<GetAllScoresQuery, PagedResponse<IEnumerable<GetAllScoresResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetAllScoresResponse>>>> Handle(GetAllScoresQuery request, CancellationToken cancellationToken) {
            var scores = await repository.GetAllAsync(cancellationToken);
            var res = scores.List.Select(s => new GetAllScoresResponse(s.Id, s.Action, s.ScoreCount));
            return new PagedResponse<IEnumerable<GetAllScoresResponse>>(res, scores.Count);
        }
    }
}
