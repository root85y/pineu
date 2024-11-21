namespace Pineu.Application.MainDomain.Discounts.Commands.Handlers;
internal class UpdateDiscountCommandHandler(IDiscountRepository repository) : ICommandHandler<UpdateDiscountCommand> {
    public async Task<Result> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken) {
        var discount = await repository.GetAsync(request.Id, cancellationToken);
        if (discount == null) return Result.Failure(DomainErrors.Discount.DiscountNotFound);

        discount.Update(request.Title, request.Description, request.OffPercentage, request.ExpiresAt, request.ScoreCost, request.StoreId);
        await repository.UpdateAsync(discount, cancellationToken);
        return Result.Success();
    }
}
