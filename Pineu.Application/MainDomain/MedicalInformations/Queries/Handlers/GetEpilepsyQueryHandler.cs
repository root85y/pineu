using Pineu.Application.MainDomain.DefaultMedicines.Queries.DTOs;
using Pineu.Application.MainDomain.MedicalInformations.Commands;
using Pineu.Application.MainDomain.MedicalInformations.Queries.DTOs;

namespace Pineu.Application.MainDomain.MedicalInformations.Queries.Handlers {
    internal class GetEpilepsyQueryHandler(IMedicalInformationRepository repository)
        : IQueryHandler<GetEpilepsyQuery, List<object>> {
        public async Task<Result<List<object>>> Handle(GetEpilepsyQuery request, CancellationToken cancellationToken) {
            var count = await repository.GetEpilepsyAsync(cancellationToken);
            return count;
        }
    }
}
