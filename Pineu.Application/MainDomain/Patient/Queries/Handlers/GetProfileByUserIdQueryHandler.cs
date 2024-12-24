using Pineu.Application.MainDomain.Profiles.Queries.DTOs;
using Pineu.Domain.Shared;

namespace Pineu.Application.MainDomain.Profiles.Queries.Handlers {
    internal class GetLestOfRegPatientQueryHandler(IProfileRepository repository)
        : IQueryHandler<GetLestOfRegPatientQuery, PagedResponse<IEnumerable<GetLestOfRegPatientResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetLestOfRegPatientResponse>>>> Handle(GetLestOfRegPatientQuery request, CancellationToken cancellationToken) {
            var profiles = await repository.GetWithDoctorIdAndPatientStatusAsync(request.DoctorID, request.status, cancellationToken);
            if (profiles == null) return Result.Failure<PagedResponse<IEnumerable<GetLestOfRegPatientResponse>>>(DomainErrors.Profile.ProfileNotFound);

            var res = profiles.List.Select(prof => new GetLestOfRegPatientResponse
                    (prof.FullName,
                    prof.Mobile,
                    prof.Birthdate,
                    prof.CreatedAt
                    )
                );
            return new PagedResponse<IEnumerable<GetLestOfRegPatientResponse>>(res, profiles.Count);

        }
    }
}
