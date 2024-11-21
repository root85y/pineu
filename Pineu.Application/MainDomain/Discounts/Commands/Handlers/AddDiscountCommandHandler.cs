namespace Pineu.Application.MainDomain.Discounts.Commands.Handlers;
internal class AddDiscountCommandHandler(IDiscountRepository repository) : ICommandHandler<AddDiscountCommand, Guid> {
    public async Task<Result<Guid>> Handle(AddDiscountCommand request, CancellationToken cancellationToken) {
        var discount = Discount.Create(Guid.NewGuid(), request.Title, request.Description, request.OffPercentage, request.ExpiresAt,
            request.ScoreCost, request.StoreId);

        await repository.AddAsync(discount, cancellationToken);
        return discount.Id;
    }
}
