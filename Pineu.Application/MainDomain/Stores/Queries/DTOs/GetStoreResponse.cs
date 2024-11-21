namespace Pineu.Application.MainDomain.Stores.Queries.DTOs {
    public sealed record GetStoreResponse(string Title, Guid? ImageId, string Address, string PhoneNumber);
}
