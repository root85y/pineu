using Pineu.Application.MainDomain.Seizures.Queries.DTOs;

namespace Pineu.Application.MainDomain.Seizures.Queries {
    public sealed record GetSeizuresChartQuery(Guid UserId, DateTime? From, DateTime? To) : IQuery<PagedResponse<IEnumerable<GetSeizuresChartResponse>>>;
}
