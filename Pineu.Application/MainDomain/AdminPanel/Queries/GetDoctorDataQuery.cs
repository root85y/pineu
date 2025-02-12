namespace Pineu.Application.MainDomain.AdminPanel.Queries;
public sealed record GetDoctorDataQuery() : IQuery<PagedResponse<IEnumerable<Pineu.Domain.Entities.MainDomain.Doctor>>>;
