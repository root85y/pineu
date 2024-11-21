using Pineu.Application.MainDomain.Newses.Queries.DTOs;

namespace Pineu.Application.MainDomain.Newses.Commands.Handlers {
    internal class UpdateNewsCommandHandler(INewsRepository repository, ISender sender) : ICommandHandler<UpdateNewsCommand> {
        public async Task<Result> Handle(UpdateNewsCommand request, CancellationToken cancellationToken) {
            var news = await repository.GetAsync(request.Id, cancellationToken);
            if (news == null) return Result.Failure<GetNewsResponse>(DomainErrors.News.NewsNotFound);

            if (request.ImageId != news.ImageId) {
                var image = await sender.Send(new GetFileUriWithIdQuery(request.ImageId), cancellationToken);
                if (image.IsFailure) return Result.Failure(image.Error);
            }

            news.Update(request.Title, request.Body, request.Link, request.ImageId);
            await repository.UpdateAsync(news, cancellationToken);

            return Result.Success();
        }
    }
}
