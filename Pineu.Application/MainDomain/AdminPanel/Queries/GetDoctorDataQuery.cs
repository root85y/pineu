using Pineu.Application.MainDomain.DoctorPrescriptions.Queries.DTOs;

namespace Pineu.Application.MainDomain.DoctorPrescriptions.Queries;
public sealed record GetDoctorDataQuery() : IQuery<PagedResponse<IEnumerable<Doctor>>>;
