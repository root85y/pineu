namespace Pineu.Application.MainDomain.Doctor.Queries {
    public sealed record GetNameOfDoctorWithIdQuery(Guid DoctorId) : IQuery<string>;
}
