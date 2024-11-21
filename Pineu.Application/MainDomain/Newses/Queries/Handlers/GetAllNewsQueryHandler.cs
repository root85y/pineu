using Pineu.Application.MainDomain.Newses.Queries.DTOs;

namespace Pineu.Application.MainDomain.Newses.Queries.Handlers {
    internal class GetAllNewsQueryHandler(INewsRepository repository, ISender sender)
        : IQueryHandler<GetAllNewsQuery, PagedResponse<IEnumerable<GetAllNewsResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetAllNewsResponse>>>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken) {
            var newses = await repository.GetAllAsync(request.Search, request.Page, request.PageSize, cancellationToken);

            var res = new List<GetAllNewsResponse>();
            foreach (var news in newses.List) {
                var image = await sender.Send(new GetFileUriWithIdQuery(news.ImageId), cancellationToken);
                res.Add(new GetAllNewsResponse(news.Id, news.Title, news.Body, news.Link,
                    image.IsSuccess ? image.Value.Url : ""));
            }
            return new PagedResponse<IEnumerable<GetAllNewsResponse>>(res, newses.Count);
        }
    }
}
