using Pineu.Application.MainDomain.Profiles.Commands;

namespace Pineu.Application.MainDomain.MentalStatuses.Commands.Handlers {
    internal class UpsertMentalStatusCommandHandler(IMentalStatusRepository repository, ISender sender) : ICommandHandler<UpsertMentalStatusCommand> {
        public async Task<Result> Handle(UpsertMentalStatusCommand request, CancellationToken cancellationToken) {
            var mentalS = await repository.GetAsync(request.UserId, request.Date, cancellationToken);
            if (mentalS == null) {
                mentalS = MentalStatus.Create(Guid.NewGuid(), request.Value, DateOnly.FromDateTime(request.Date), request.UserId);
                await repository.AddAsync(mentalS, cancellationToken);
                await sender.Send(new UpdateProfileScoreCommand(ScoreAction.AddMentalStatus, request.UserId, null), cancellationToken);
            } else {
                mentalS.Update(request.Value);
                await repository.UpdateAsync(mentalS, cancellationToken);
            }
            return Result.Success();
        }
    }
}
