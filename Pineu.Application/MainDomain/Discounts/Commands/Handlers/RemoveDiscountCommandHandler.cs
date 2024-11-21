namespace Pineu.Application.MainDomain.Discounts.Commands.Handlers;
internal class RemoveDiscountCommandHandler(IDiscountRepository repository) : ICommandHandler<RemoveDiscountCommand> {
    public async Task<Result> Handle(RemoveDiscountCommand request, CancellationToken cancellationToken) {
        var discount = await repository.GetAsync(request.Id, cancellationToken);
        if (discount == null) return Result.Failure(DomainErrors.Discount.DiscountNotFound);

        await repository.RemoveAsync(discount, cancellationToken);
        return Result.Success(discount);
    }
}
