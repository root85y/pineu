using Pineu.Application.MainDomain.Profiles.Queries.DTOs;

namespace Pineu.Application.MainDomain.Profiles.Queries.Handlers {
    internal class GetProfileByUserIdQueryHandler(IProfileRepository repository)
        : IQueryHandler<GetProfileByUserIdQuery, GetProfileResponse> {
        public async Task<Result<GetProfileResponse>> Handle(GetProfileByUserIdQuery request, CancellationToken cancellationToken) {
            var profile = await repository.GetAsync(request.UserId, cancellationToken);
            if (profile == null) return Result.Failure<GetProfileResponse>(DomainErrors.Profile.ProfileNotFound);

            return new GetProfileResponse(profile.UserId,profile.FullName, profile.Gender, profile.Birthdate, profile.MaritalStatus, profile.Score,profile.Status, request.PhoneNumber);
        }
    }
}
