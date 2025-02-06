using Pineu.Application.MainDomain.Profiles.Queries.DTOs;

namespace Pineu.Application.MainDomain.Profiles.Queries.Handlers {
    internal class GetProfileCountQueryHandler(IProfileRepository repository)
        : IQueryHandler<GetProfileCountQuery, int> {
        public async Task<Result<int>> Handle(GetProfileCountQuery request, CancellationToken cancellationToken) {
            int Usercount = await repository.UserCountGetAsync(cancellationToken);
            return (Usercount);
        }
    }
}
