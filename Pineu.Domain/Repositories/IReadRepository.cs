namespace Pineu.Domain.Repositories;
public interface IReadRepository<T, TKey> : IReadRepositoryBase<T> where T : Entity<TKey> {
}