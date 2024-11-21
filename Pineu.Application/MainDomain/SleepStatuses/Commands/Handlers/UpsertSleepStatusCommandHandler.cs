using Pineu.Application.MainDomain.Profiles.Commands;

namespace Pineu.Application.MainDomain.SleepStatuses.Commands.Handlers {
    internal class UpsertSleepStatusCommandHandler(ISleepStatusRepository repository, ISender sender) : ICommandHandler<UpsertSleepStatusCommand> {
        public async Task<Result> Handle(UpsertSleepStatusCommand request, CancellationToken cancellationToken) {
            var sleepS = await repository.GetAsync(request.UserId, request.Date, cancellationToken);
            if (sleepS == null) {
                sleepS = SleepStatus.Create(Guid.NewGuid(), request.Value, DateOnly.FromDateTime(request.Date), request.UserId);
                await repository.AddAsync(sleepS, cancellationToken);
                await sender.Send(new UpdateProfileScoreCommand(ScoreAction.AddSleepStatus, request.UserId, null), cancellationToken);
            } else {
                sleepS.Update(request.Value);
                await repository.UpdateAsync(sleepS, cancellationToken);
            }
            return Result.Success();
        }
    }
}
