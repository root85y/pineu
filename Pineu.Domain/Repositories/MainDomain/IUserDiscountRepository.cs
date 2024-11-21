namespace Pineu.Domain.Repositories.MainDomain;
public interface IUserDiscountRepository {
    Task RemoveAsync(UserDiscount userDiscount, CancellationToken cancellationToken = default);
    Task AddAsync(UserDiscount userDiscount, CancellationToken cancellationToken = default);
    Task<UserDiscount?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<PagedResponse<IEnumerable<UserDiscount>>> GetAllAsync(int? page, int? pageSize, Guid? userId,
        CancellationToken cancellationToken = default);
}
