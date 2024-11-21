using Pineu.Persistence.Specifications.MainDomain.Scores;

namespace Pineu.Persistence.Repositories.MainDomain {
    public class ScoreRepository(IRepository<Score, Guid> repository) : IScoreRepository {
        public async Task<PagedResponse<IEnumerable<Score>>> GetAllAsync(CancellationToken cancellationToken = default) =>
            new PagedResponse<IEnumerable<Score>>(await repository.ListAsync(cancellationToken), await repository.CountAsync(cancellationToken));

        public async Task<Score?> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
            await repository.GetByIdAsync(id, cancellationToken);

        public async Task<Score?> GetAsync(ScoreAction action, CancellationToken cancellationToken = default) =>
            await repository.FirstOrDefaultAsync(new GetScoreByActionSpecification(action), cancellationToken);

        public async Task UpdateAsync(Score score, CancellationToken cancellationToken = default) =>
            await repository.UpdateAsync(score, cancellationToken);
    }
}
