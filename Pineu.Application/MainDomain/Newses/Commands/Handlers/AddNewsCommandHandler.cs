namespace Pineu.Application.MainDomain.Newses.Commands.Handlers {
    internal class AddNewsCommandHandler(INewsRepository repository, ISender sender) : ICommandHandler<AddNewsCommand, Guid> {
        public async Task<Result<Guid>> Handle(AddNewsCommand request, CancellationToken cancellationToken) {
            var image = await sender.Send(new GetFileUriWithIdQuery(request.ImageId), cancellationToken);
            if (image.IsFailure) return Result.Failure<Guid>(image.Error);

            var news = News.Create(Guid.NewGuid(), request.Title, request.Body, request.Link, request.ImageId);
            await repository.AddAsync(news, cancellationToken);

            return news.Id;
        }
    }
}
