using Pineu.Domain.Repositories;
using Pineu.Persistence.Specifications.MainDomain.MedicalInformations;

namespace Pineu.Persistence.Repositories.MainDomain {
    public class MedicalInformationRepository(IRepository<MedicalInformation, Guid> repository) : IMedicalInformationRepository {
        public async Task AddAsync(MedicalInformation medicalInformation, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(medicalInformation, cancellationToken);

        public async Task<MedicalInformation?> GetAsync(Guid userId, CancellationToken cancellationToken = default) =>
            await repository.FirstOrDefaultAsync(new GetMedicalInformationByIdSpecification(userId), cancellationToken);

        public async Task UpdateAsync(MedicalInformation medicalInformation, CancellationToken cancellationToken = default) =>
            await repository.UpdateAsync(medicalInformation, cancellationToken);

        public async Task<List<object>> GetEpilepsyAsync(CancellationToken cancellationToken) {
            var allEpilepsyTypeCounts = await repository.ListAsync(new GetEpilepsyTypeCountsSpecification(), cancellationToken);

            var counts = allEpilepsyTypeCounts
                .GroupBy(mi => mi.EpilepsyTypeId)
                .Select(g => new {
                    EpilepsyTypeId = g.Key,
                    Count = g.Count()
                })
                .ToList();

            var result = counts
                .Select(c => new {
                    type = c.EpilepsyTypeId switch {
                        1 => "فوکال",
                        2 => "ژنرالیزه",
                        3 => "ترکیب فوکال و ژنرالیزه",
                        4 => "ناشناخته"
                    },
                    count = c.Count
                })
            .ToList<object>();


            return result;
        }
    }
}
