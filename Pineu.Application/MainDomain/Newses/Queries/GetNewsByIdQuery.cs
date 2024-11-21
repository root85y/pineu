using Pineu.Application.MainDomain.Newses.Queries.DTOs;

namespace Pineu.Application.MainDomain.Newses.Queries {
    public sealed record GetNewsByIdQuery(Guid Id) : IQuery<GetNewsResponse>;
}
