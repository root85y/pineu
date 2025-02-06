using Pineu.Application.MainDomain.DoctorPrescriptions.Queries.DTOs;

namespace Pineu.Application.MainDomain.DoctorPrescriptions.Queries;
public sealed record GetUserDataQuery() : IQuery<PagedResponse<IEnumerable<Profile>>>;
