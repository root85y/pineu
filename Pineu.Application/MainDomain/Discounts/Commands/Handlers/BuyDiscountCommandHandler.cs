using Pineu.Application.MainDomain.Profiles.Commands;
using Pineu.Application.MainDomain.UserDiscounts.Commands;

namespace Pineu.Application.MainDomain.Discounts.Commands.Handlers {
    internal class BuyDiscountCommandHandler(ISender sender) : ICommandHandler<BuyDiscountCommand, string> {
        public async Task<Result<string>> Handle(BuyDiscountCommand request, CancellationToken cancellationToken) {
            var profileRes = await sender.Send(new UpdateProfileScoreCommand(ScoreAction.BuyDiscount, request.UserId, request.DiscountId), cancellationToken);
            if (profileRes.IsFailure) return Result.Failure<string>(profileRes.Error);

            var userDiscount = await sender.Send(new AddUserDiscountCommand(request.DiscountId, request.UserId), cancellationToken);
            if (userDiscount.IsFailure) return Result.Failure<string>(userDiscount.Error);

            return userDiscount.Value;
        }
    }
}
