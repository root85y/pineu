using Pineu.Domain.Entities.Types;
using Pineu.Domain.Repositories.Types;
using Pineu.Persistence.Specifications.Types;

namespace Pineu.Persistence.Repositories.Types;

internal class DateTimeUnitTypeRepository (IRepository<DateTimeUnitType, short> repository) : IDateTimeUnitTypeRepository {
    public async Task<IEnumerable<DateTimeUnitType>> GetAllAsync(IEnumerable<short>? ids, string? search,
        CancellationToken cancellationToken = default) =>
        await repository.ListAsync(new GetAllDateTimeUnitTypeSpecification(ids, search), cancellationToken);
}