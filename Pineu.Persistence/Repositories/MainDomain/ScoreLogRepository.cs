using Pineu.Persistence.Specifications.MainDomain.ScoreLogs;

namespace Pineu.Persistence.Repositories.MainDomain {
    public class ScoreLogRepository(IRepository<ScoreLog, Guid> repository) : IScoreLogRepository {
        public async Task AddAsync(ScoreLog scoreLog, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(scoreLog, cancellationToken);

        public async Task<PagedResponse<IEnumerable<ScoreLog>>> GetAllAsync(DateTime? from, DateTime? to, int? page, int? pageSize,
            Guid? userId, ScoreType? type, CancellationToken cancellationToken = default) {
            var specification = new GetAllScoreLogsSpecification(from, to, userId, type);
            var count = await repository.CountAsync(specification, cancellationToken);
            if (page.HasValue && pageSize.HasValue)
                specification.ToPaged(page.Value, pageSize.Value);

            return new PagedResponse<IEnumerable<ScoreLog>>(await repository.ListAsync(specification, cancellationToken), count);
        }
    }
}
