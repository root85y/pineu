using Pineu.Application.MainDomain.ScoreLogs.Queries.DTOs;

namespace Pineu.Application.MainDomain.ScoreLogs.Queries.Handlers {
    internal class GetAllScoreLogsQueryHandler(IScoreLogRepository repository)
        : IQueryHandler<GetAllScoreLogsQuery, PagedResponse<IEnumerable<GetAllScoreLogsResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetAllScoreLogsResponse>>>> Handle(GetAllScoreLogsQuery request, CancellationToken cancellationToken) {
            var scoreLogs = await repository.GetAllAsync(request.From, request.To, request.Page, request.PageSize,
                request.UserId, request.Type, cancellationToken);

            var res = scoreLogs.List.Select(s => new GetAllScoreLogsResponse(
                s.Change, s.Action, s.Discount?.Title, s.CreatedAt));
            return new PagedResponse<IEnumerable<GetAllScoreLogsResponse>>(res, scoreLogs.Count);
        }
    }
}
