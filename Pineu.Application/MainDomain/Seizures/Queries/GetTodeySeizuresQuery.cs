using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.Seizures.Queries.DTOs;

namespace Pineu.Application.MainDomain.Seizures.Queries {
    public sealed record GetTodeySeizuresQuery(Guid DoctorId,Profile PatientData)
        : IQuery<int>;
}
