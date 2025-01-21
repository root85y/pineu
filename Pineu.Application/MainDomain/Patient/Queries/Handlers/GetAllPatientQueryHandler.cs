using Pineu.Application.MainDomain.Patient.Queries;
using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.Profiles.Queries.DTOs;

namespace Pineu.Application.MainDomain.Profiles.Queries.Handlers {
    internal class GetAllPatientQueryHandler(IProfileRepository repository)
        : IQueryHandler<GetAllPatientQuery, PagedResponse<IEnumerable<Profile>>> {
        public async Task<Result<PagedResponse<IEnumerable<Profile>>>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken) {
            var profiles = await repository.GetWithDoctorIdAndPatientStatusAsync(request.DoctorID, request.status, cancellationToken);
            if (profiles == null)
                return Result.Failure<PagedResponse<IEnumerable<Profile>>>(DomainErrors.Profile.ProfileNotFound);

            return profiles;
        }
    }
}
