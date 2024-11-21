namespace Pineu.Domain.Repositories;
public interface IRepository<T, TKey> : IRepositoryBase<T> where T : Entity<TKey> {
}