using Pineu.Application.MainDomain.DoctorPrescriptions.Queries.DTOs;

namespace Pineu.Application.MainDomain.AdminPanel.Queries;
public sealed record GetUserNotRegisteredDataQuery(string Status) : IQuery<PagedResponse<IEnumerable<Profile>>>;
