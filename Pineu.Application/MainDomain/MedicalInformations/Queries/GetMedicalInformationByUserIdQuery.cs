using Pineu.Application.MainDomain.MedicalInformations.Queries.DTOs;

namespace Pineu.Application.MainDomain.MedicalInformations.Queries {
    public sealed record GetMedicalInformationByUserIdQuery(Guid UserId) : IQuery<GetMedicalInformationResponse>;
}
