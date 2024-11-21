using Pineu.Domain.Entities.Types;

namespace Pineu.Domain.Repositories.Types;

public interface IPastYearComplaintTypeRepository {
    Task<IEnumerable<PastYearComplaintType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default);
}