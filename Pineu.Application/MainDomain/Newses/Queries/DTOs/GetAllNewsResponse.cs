namespace Pineu.Application.MainDomain.Newses.Queries.DTOs {
    public sealed record GetAllNewsResponse(Guid Id, string Title, string Body, string Link, string ImageUrl);
}
