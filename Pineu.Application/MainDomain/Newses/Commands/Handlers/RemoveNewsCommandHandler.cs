using Pineu.Application.MainDomain.Newses.Queries.DTOs;

namespace Pineu.Application.MainDomain.Newses.Commands.Handlers {
    internal class RemoveNewsCommandHandler(INewsRepository repository) : ICommandHandler<RemoveNewsCommand> {
        public async Task<Result> Handle(RemoveNewsCommand request, CancellationToken cancellationToken) {
            var news = await repository.GetAsync(request.Id, cancellationToken);
            if (news == null) return Result.Failure<GetNewsResponse>(DomainErrors.News.NewsNotFound);

            await repository.RemoveAsync(news, cancellationToken);
            return Result.Success();
        }
    }
}
