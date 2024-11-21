using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.Profiles.Queries.DTOs;

namespace Pineu.Application.MainDomain.Profiles.Queries.Handlers {
    internal class GetAllPatientDataQueryHandler(IProfileRepository repository)
        : IQueryHandler<GetAllPatientDataQuery, GetFullProfileResponse> {
        public async Task<Result<GetFullProfileResponse>> Handle(GetAllPatientDataQuery request, CancellationToken cancellationToken) {
            var profile = await repository.GetFullProfileAsync(request.userid,request.doctorid ,cancellationToken);
            if (profile == null) return Result.Failure<GetFullProfileResponse>(DomainErrors.Profile.ProfileNotFound);

            return new GetFullProfileResponse(
                profile.UserId,
                profile.FullName,
                profile.Gender,
                profile.Birthdate,
                profile.MaritalStatus,
                profile.Mobile,
                profile.DoctorId,
                profile.Status);
        }
    }
}
