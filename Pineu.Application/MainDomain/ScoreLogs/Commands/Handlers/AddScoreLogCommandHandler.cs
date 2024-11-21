namespace Pineu.Application.MainDomain.ScoreLogs.Commands.Handlers {
    internal class AddScoreLogCommandHandler(IScoreLogRepository repository) : ICommandHandler<AddScoreLogCommand> {
        public async Task<Result> Handle(AddScoreLogCommand request, CancellationToken cancellationToken) {
            var scoreLog = ScoreLog.Create(Guid.NewGuid(), request.UserId, request.Change, request.RemainingScore, request.Action, request.DiscountId);
            await repository.AddAsync(scoreLog, cancellationToken);

            return Result.Success();
        }
    }
}
