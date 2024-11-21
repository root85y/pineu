using Pineu.Application.MainDomain.DoctorPrescriptions.Queries.DTOs;

namespace Pineu.Application.MainDomain.DoctorPrescriptions.Queries.Handlers;
internal class GetAllDoctorPrescriptionsQueryHandler(IDoctorPrescriptionRepository repository)
    : IQueryHandler<GetAllDoctorPrescriptionsQuery, PagedResponse<IEnumerable<GetAllDoctorPrescriptionsResponse>>> {
    public async Task<Result<PagedResponse<IEnumerable<GetAllDoctorPrescriptionsResponse>>>> Handle(GetAllDoctorPrescriptionsQuery request, CancellationToken cancellationToken) {
        var doctorPs = await repository.GetAllAsync(request.From, request.To, request.Page, request.PageSize, request.UserId, cancellationToken);

        var res = doctorPs.List.Select(dp => new GetAllDoctorPrescriptionsResponse(
            dp.DoctorName, dp.VisitContent, dp.VisitedAt)
        );
        return new PagedResponse<IEnumerable<GetAllDoctorPrescriptionsResponse>>(res, doctorPs.Count);
    }
}
