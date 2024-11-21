using Pineu.Application.MainDomain.Stores.Queries.DTOs;

namespace Pineu.Application.MainDomain.Stores.Queries {
    public sealed record GetStoreByIdQuery(Guid Id) : IQuery<GetStoreResponse>;
}
