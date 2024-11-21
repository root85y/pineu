using Pineu.Application.MainDomain.Discounts.Queries.DTOs;

namespace Pineu.Application.MainDomain.Discounts.Queries;
public sealed record GetDiscountByIdQuery(Guid Id) : IQuery<GetDiscountResponse>;
