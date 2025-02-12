using Pineu.Application.MainDomain.Profiles.Queries.DTOs;
using Pineu.Domain.Shared;

namespace Pineu.Application.MainDomain.Profiles.Queries.Handlers {
    internal class GetAllUserQueryHandler(IProfileRepository repository)
        : IQueryHandler<GetAllUserQuery, PagedResponse<IEnumerable<GetLestOfRegPatientResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetLestOfRegPatientResponse>>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken) {
            var profiles = await repository.GetAllPatientStatusAsync(request.status, cancellationToken);
            if (profiles == null)
                return Result.Failure<PagedResponse<IEnumerable<GetLestOfRegPatientResponse>>>(DomainErrors.Profile.ProfileNotFound);

            var res = profiles.List.Select(prof => new GetLestOfRegPatientResponse
                    (
                    prof.UserId,
                    prof.FullName,
                    prof.Mobile,
                    prof.Birthdate,
                    prof.CreatedAt
                    )
                );
            return new PagedResponse<IEnumerable<GetLestOfRegPatientResponse>>(res, profiles.Count);

        }
    }
}
