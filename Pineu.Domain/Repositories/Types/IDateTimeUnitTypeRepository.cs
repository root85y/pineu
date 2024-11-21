using Pineu.Domain.Entities.Types;

namespace Pineu.Domain.Repositories.Types;

public interface IDateTimeUnitTypeRepository {
    Task<IEnumerable<DateTimeUnitType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default);
}