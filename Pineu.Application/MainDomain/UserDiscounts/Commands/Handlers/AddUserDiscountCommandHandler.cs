using Pineu.Application.MainDomain.Discounts.Queries;

namespace Pineu.Application.MainDomain.UserDiscounts.Commands.Handlers {
    internal class AddUserDiscountCommandHandler(IUserDiscountRepository repository, ISender sender) : ICommandHandler<AddUserDiscountCommand, string> {
        public async Task<Result<string>> Handle(AddUserDiscountCommand request, CancellationToken cancellationToken) {
            var discount = await sender.Send(new GetDiscountByIdQuery(request.DiscountId), cancellationToken);
            if (discount.IsFailure) return Result.Failure<string>(discount.Error);

            var userDiscount = UserDiscount.Create(Guid.NewGuid(), request.DiscountId, request.UserId);
            await repository.AddAsync(userDiscount, cancellationToken);
            return userDiscount.DiscountCode;
        }
    }
}
