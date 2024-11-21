namespace Pineu.Application.MainDomain.Newses.Queries.DTOs {
    public sealed record GetNewsResponse(string Title, string Body, string Link, Guid ImageId);
}
