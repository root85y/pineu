namespace Pineu.Application.MainDomain.Profiles.Commands.Handlers
{
    internal class UpsertProfileCommandHandler(IProfileRepository repository) : ICommandHandler<UpsertProfileCommand>
    {
        public async Task<Result> Handle(UpsertProfileCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.UserType))
            {
                var profile = await repository.GetAsync(request.UserId, cancellationToken);
                if (profile == null)
                {
                    profile = Profile.Create(Guid.NewGuid(), request.FullName, request.Gender, request.Birthdate,
                        request.MaritalStatus,request.PhoneNumber ,null, request.Status, request.UserId);
                    await repository.AddAsync(profile, cancellationToken);
                }
                else
                {
                    profile.Update(request.FullName, request.Gender, request.Birthdate, request.MaritalStatus, null, request.Status);
                    await repository.UpdateAsync(profile, cancellationToken);
                }
                return Result.Success();
            }
            else
            {
                var profile = await repository.GetAsync(request.UserId, cancellationToken);
                if (profile == null)
                {
                    profile = Profile.Create(Guid.NewGuid(), request.FullName, request.Gender, request.Birthdate,
                        request.MaritalStatus,request.PhoneNumber, null, request.Status, request.UserId);
                    await repository.AddAsync(profile, cancellationToken);
                }
                else
                {
                    profile.Update(request.FullName, request.Gender, request.Birthdate, request.MaritalStatus, null, request.Status);
                    await repository.UpdateAsync(profile, cancellationToken);
                }
                return Result.Success();
            }
        }
    }
}
