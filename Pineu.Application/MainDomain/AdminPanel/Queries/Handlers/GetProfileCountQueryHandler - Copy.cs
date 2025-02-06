using Pineu.Application.MainDomain.Profiles.Queries.DTOs;

namespace Pineu.Application.MainDomain.Profiles.Queries.Handlers {
    internal class GetDoctorCountQueryHandler(IDoctorRepository repository)
        : IQueryHandler<GetDoctorCountQuery, int> {
        public async Task<Result<int>> Handle(GetDoctorCountQuery request, CancellationToken cancellationToken) {
            int Usercount = await repository.UserCountGetAsync(cancellationToken);
            return (Usercount);
        }
    }
}
