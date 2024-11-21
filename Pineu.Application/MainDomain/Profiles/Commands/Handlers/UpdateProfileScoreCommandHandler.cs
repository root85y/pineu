using Pineu.Application.MainDomain.Discounts.Queries;
using Pineu.Application.MainDomain.ScoreLogs.Commands;
using Pineu.Application.MainDomain.Scores.Queries;

namespace Pineu.Application.MainDomain.Profiles.Commands.Handlers {
    internal class UpdateProfileScoreCommandHandler(IProfileRepository profileRepository, ISender sender, IUserDiscountRepository userDiscountRepository)
        : ICommandHandler<UpdateProfileScoreCommand> {
        public async Task<Result> Handle(UpdateProfileScoreCommand request, CancellationToken cancellationToken) {
            var profile = await profileRepository.GetAsync(request.UserId, cancellationToken);
            if (profile == null) return Result.Failure(DomainErrors.Profile.ProfileNotFound);
            if (request.Action == ScoreAction.BuyDiscount) {
                var discount = await sender.Send(new GetDiscountByIdQuery(request.DiscountId!.Value), cancellationToken);
                if (discount.IsFailure) return Result.Failure(discount.Error);

                var userDiscounts = await userDiscountRepository.GetAllAsync(null, null, request.UserId, cancellationToken);
                if (userDiscounts.List.Any(ud => ud.DiscountId == request.DiscountId))
                    return Result.Failure(DomainErrors.Discount.AlreadyBoughtDiscount);

                if (profile.Score < discount.Value.ScoreCost) return Result.Failure(DomainErrors.Profile.NotEnoughScore);

                var change = 0 - discount.Value.ScoreCost;
                profile.UpdateScore(change);
                await profileRepository.UpdateAsync(profile, cancellationToken);
                await sender.Send(new AddScoreLogCommand(request.UserId, change, profile.Score, ScoreAction.BuyDiscount, request.DiscountId),
                    cancellationToken);
            } else {
                var score = await sender.Send(new GetScoreByActionQuery(request.Action), cancellationToken);
                if (score.IsFailure) return Result.Failure(score.Error);

                profile.UpdateScore(score.Value.ScoreCount);
                await profileRepository.UpdateAsync(profile, cancellationToken);
                await sender.Send(new AddScoreLogCommand(request.UserId, score.Value.ScoreCount, profile.Score, request.Action, null),
                    cancellationToken);
            }
            return Result.Success();
        }
    }
}
