namespace Pineu.Application.MainDomain.Stores.Queries.DTOs {
    public sealed record GetAllStoresResponse(Guid Id, string Title, string Address, string PhoneNumber, string ImageUrl, int? TopOffer);
}
