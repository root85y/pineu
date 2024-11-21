namespace Pineu.Application.MainDomain.Profiles.Commands.Handlers
{
    internal class UpsertDoctorCommandHandler(IDoctorRepository repository) : ICommandHandler<UpsertDoctorCommand>
    {
        public async Task<Result> Handle(UpsertDoctorCommand request, CancellationToken cancellationToken)
        {
            await repository.AddAsync(request.doctor, cancellationToken);
            return Result.Success();
        }
    }
}
