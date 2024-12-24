using Pineu.Application.MainDomain.Discounts.Queries;
using Pineu.Application.MainDomain.ScoreLogs.Commands;
using Pineu.Application.MainDomain.Scores.Queries;
using Pineu.Domain.Repositories;

namespace Pineu.Application.MainDomain.Profiles.Commands.Handlers;

internal class UpdateProfileCommandHandler(IProfileRepository profileRepository, ISender sender, IUserDiscountRepository userDiscountRepository)
    : ICommandHandler<UpdateProfileCommand>{
    public async Task<Result> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {

        var profile = await profileRepository.GetAsync(request.UserId, cancellationToken);
        if (profile == null) return Result.Failure(DomainErrors.Profile.ProfileNotFound);
        profile.Update(profile.FullName, profile.Gender, profile.Birthdate, profile.MaritalStatus, request.Doctor, null);
        await profileRepository.UpdateAsync(profile, cancellationToken);
        return Result.Success();
    }
}
