namespace Pineu.Domain.Repositories.MainDomain;
public interface IScoreLogRepository {
    Task AddAsync(ScoreLog scoreLog, CancellationToken cancellationToken = default);

    Task<PagedResponse<IEnumerable<ScoreLog>>> GetAllAsync(DateTime? from, DateTime? to, int? page, int? pageSize, Guid? userId,
        ScoreType? Type, CancellationToken cancellationToken = default);
}
