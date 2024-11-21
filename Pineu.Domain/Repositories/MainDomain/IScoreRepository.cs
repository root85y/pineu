namespace Pineu.Domain.Repositories.MainDomain;
public interface IScoreRepository {
    Task UpdateAsync(Score score, CancellationToken cancellationToken = default);
    Task<Score?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Score?> GetAsync(ScoreAction action, CancellationToken cancellationToken = default);

    Task<PagedResponse<IEnumerable<Score>>> GetAllAsync(CancellationToken cancellationToken = default);
}
