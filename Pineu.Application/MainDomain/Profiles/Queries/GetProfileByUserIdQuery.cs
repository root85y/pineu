using Pineu.Application.MainDomain.Profiles.Queries.DTOs;

namespace Pineu.Application.MainDomain.Profiles.Queries {
    public sealed record GetProfileByUserIdQuery(Guid UserId, string PhoneNumber) : IQuery<GetProfileResponse>;
}
