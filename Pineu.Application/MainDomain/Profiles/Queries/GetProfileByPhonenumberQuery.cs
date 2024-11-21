using Pineu.Application.MainDomain.Profiles.Queries.DTOs;

namespace Pineu.Application.MainDomain.Profiles.Queries {
    public sealed record GetProfileByPhonenumberQuery(string PhoneNumber) : IQuery<GetProfileResponse>;
}
