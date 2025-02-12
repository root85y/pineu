using Pineu.Application.MainDomain.Profiles.Queries.DTOs;

namespace Pineu.Application.MainDomain.Profiles.Queries {
    public sealed record GetAllUserQuery(string status) : IQuery<PagedResponse<IEnumerable<GetLestOfRegPatientResponse>>>;
}
