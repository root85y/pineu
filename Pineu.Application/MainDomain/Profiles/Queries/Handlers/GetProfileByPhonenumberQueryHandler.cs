using Pineu.Application.MainDomain.Profiles.Queries.DTOs;

namespace Pineu.Application.MainDomain.Profiles.Queries.Handlers {
    internal class GetProfileByPhonenumberQueryHandler(IProfileRepository repository)
        : IQueryHandler<GetProfileByPhonenumberQuery, GetProfileResponse> {
        public async Task<Result<GetProfileResponse>> Handle(GetProfileByPhonenumberQuery request, CancellationToken cancellationToken) {
            var profile = await repository.GetWithPhoneAsync(request.PhoneNumber, cancellationToken);
            if (profile == null) return Result.Failure<GetProfileResponse>(DomainErrors.Profile.ProfileNotFound);

            return new GetProfileResponse(profile.UserId ,profile.FullName, profile.Gender, profile.Birthdate, profile.MaritalStatus, profile.Score, request.PhoneNumber);
        }
    }
}
