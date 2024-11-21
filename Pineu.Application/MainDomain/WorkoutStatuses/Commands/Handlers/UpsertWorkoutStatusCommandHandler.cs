using Pineu.Application.MainDomain.Profiles.Commands;

namespace Pineu.Application.MainDomain.WorkoutStatuses.Commands.Handlers {
    internal class UpsertWorkoutStatusCommandHandler(IWorkoutStatusRepository repository, ISender sender) : ICommandHandler<UpsertWorkoutStatusCommand> {
        public async Task<Result> Handle(UpsertWorkoutStatusCommand request, CancellationToken cancellationToken) {
            var workoutS = await repository.GetAsync(request.UserId, request.Date, cancellationToken);
            if (workoutS == null) {
                workoutS = WorkoutStatus.Create(Guid.NewGuid(), request.Value, DateOnly.FromDateTime(request.Date), request.UserId);
                await repository.AddAsync(workoutS, cancellationToken);
                await sender.Send(new UpdateProfileScoreCommand(ScoreAction.AddWorkoutStatus, request.UserId, null), cancellationToken);
            } else {
                workoutS.Update(request.Value);
                await repository.UpdateAsync(workoutS, cancellationToken);
            }
            return Result.Success();
        }
    }
}
