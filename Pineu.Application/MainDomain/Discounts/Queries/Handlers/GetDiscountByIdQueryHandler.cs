using Pineu.Application.MainDomain.Discounts.Queries.DTOs;
using Pineu.Application.SystemFiles.Commands.DTOs;

namespace Pineu.Application.MainDomain.Discounts.Queries.Handlers;
internal class GetDiscountByIdQueryHandler(IDiscountRepository repository, ISender sender)
    : IQueryHandler<GetDiscountByIdQuery, GetDiscountResponse> {
    public async Task<Result<GetDiscountResponse>> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken) {
        var discount = await repository.GetAsync(request.Id, cancellationToken);
        if (discount == null) return Result.Failure<GetDiscountResponse>(DomainErrors.Discount.DiscountNotFound);

        Result<SystemFileResponse> storeImage = null;
        if (discount.Store.ImageId.HasValue)
            storeImage = await sender.Send(new GetFileUriWithIdQuery(discount.Store.ImageId.Value), cancellationToken);

        return new GetDiscountResponse(
            discount.Id,
            discount.Title,
            discount.Description,
            discount.OffPercentage,
            discount.ExpiresAt,
            discount.ScoreCost,
            discount.Store.Title,
            storeImage != null && storeImage.IsSuccess ? storeImage.Value.Url : "",
            discount.Store.PhoneNumber,
            discount.Store.Address);
    }
}
