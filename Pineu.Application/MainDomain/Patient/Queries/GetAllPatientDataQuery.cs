using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.Profiles.Queries.DTOs;

namespace Pineu.Application.MainDomain.Profiles.Queries {
    public sealed record GetAllPatientDataQuery(Guid userid,Guid doctorid) : IQuery<GetFullProfileResponse>;
}
