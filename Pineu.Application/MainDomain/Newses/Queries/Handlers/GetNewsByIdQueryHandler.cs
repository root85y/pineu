using Pineu.Application.MainDomain.Newses.Queries.DTOs;

namespace Pineu.Application.MainDomain.Newses.Queries.Handlers {
    internal class GetNewsByIdQueryHandler(INewsRepository repository) : IQueryHandler<GetNewsByIdQuery, GetNewsResponse> {
        public async Task<Result<GetNewsResponse>> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken) {
            var news = await repository.GetAsync(request.Id, cancellationToken);
            if (news == null) return Result.Failure<GetNewsResponse>(DomainErrors.News.NewsNotFound);

            return new GetNewsResponse(news.Title, news.Body, news.Link, news.ImageId);
        }
    }
}
