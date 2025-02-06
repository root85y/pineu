using Pineu.Application.MainDomain.DoctorPrescriptions.Queries.DTOs;

namespace Pineu.Application.MainDomain.DoctorPrescriptions.Queries.Handlers;
internal class GetDoctorDataQueryHandler(IDoctorRepository repository)
    : IQueryHandler<GetDoctorDataQuery, PagedResponse<IEnumerable<Doctor>>> {
    public async Task<Result<PagedResponse<IEnumerable<Doctor>>>> Handle(GetDoctorDataQuery request, CancellationToken cancellationToken) {
        var doctorData = await repository.GetAllDoctorDataAsync(cancellationToken);
        return new PagedResponse<IEnumerable<Doctor>>(doctorData, doctorData.Count);
    }
}
