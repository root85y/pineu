namespace Pineu.Application.MainDomain.Patient.Queries;
public sealed record GetAllPatientQuery(Guid DoctorID , string status) : IQuery<PagedResponse<IEnumerable<Profile>>>;
