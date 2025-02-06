using Pineu.Application.MainDomain.DoctorPrescriptions.Queries.DTOs;

namespace Pineu.Application.MainDomain.DoctorPrescriptions.Queries.Handlers;
internal class GetUserDataQueryHandler(IProfileRepository repository)
    : IQueryHandler<GetUserDataQuery, PagedResponse<IEnumerable<Profile>>> {
    public async Task<Result<PagedResponse<IEnumerable<Profile>>>> Handle(GetUserDataQuery request, CancellationToken cancellationToken) {
        var doctorData = await repository.GetAllUserDataAsync(cancellationToken);
        return new PagedResponse<IEnumerable<Profile>>(doctorData, doctorData.Count);
    }
}
