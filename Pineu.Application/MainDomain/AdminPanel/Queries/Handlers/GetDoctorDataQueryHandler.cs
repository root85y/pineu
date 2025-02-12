using Pineu.Application.MainDomain.AdminPanel.Queries;
using Pineu.Application.MainDomain.DoctorPrescriptions.Queries.DTOs;

namespace Pineu.Application.MainDomain.AdminPanel.Queries.Handlers;
internal class GetDoctorDataQueryHandler(IDoctorRepository repository)
    : IQueryHandler<GetDoctorDataQuery, PagedResponse<IEnumerable<Pineu.Domain.Entities.MainDomain.Doctor>>> {
    public async Task<Result<PagedResponse<IEnumerable<Pineu.Domain.Entities.MainDomain.Doctor>>>> Handle(GetDoctorDataQuery request, CancellationToken cancellationToken) {
        var doctorData = await repository.GetAllDoctorDataAsync(cancellationToken);
        return new PagedResponse<IEnumerable<Pineu.Domain.Entities.MainDomain.Doctor>>(doctorData, doctorData.Count);
    }
}
