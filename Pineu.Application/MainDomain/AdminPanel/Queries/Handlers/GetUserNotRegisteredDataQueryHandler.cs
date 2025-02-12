using Pineu.Application.MainDomain.AdminPanel.Queries;
using Pineu.Application.MainDomain.DoctorPrescriptions.Queries.DTOs;

namespace Pineu.Application.MainDomain.AdminPanel.Queries.Handlers;
internal class GetUserNotRegisteredDataQueryHandler(IProfileRepository repository)
    : IQueryHandler<GetUserNotRegisteredDataQuery, PagedResponse<IEnumerable<Profile>>> {
    public async Task<Result<PagedResponse<IEnumerable<Profile>>>> Handle(GetUserNotRegisteredDataQuery request, CancellationToken cancellationToken) {
        var doctorData = await repository.GetAllUserNotRegisteredDataAsync(request.Status, cancellationToken);
        return new PagedResponse<IEnumerable<Profile>>(doctorData, doctorData.Count);
    }
}
