using Pineu.Application.MainDomain.DoctorPrescriptions.Queries.DTOs;

namespace Pineu.Application.MainDomain.DoctorPrescriptions.Queries;
public sealed record GetAllDoctorPrescriptionsQuery(Guid UserId, DateTime? From, DateTime? To, int? Page, int? PageSize)
    : IQuery<PagedResponse<IEnumerable<GetAllDoctorPrescriptionsResponse>>>;
