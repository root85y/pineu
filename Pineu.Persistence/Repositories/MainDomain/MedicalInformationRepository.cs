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

        public async Task<int[,]> GetEpilepsyAsync(CancellationToken cancellationToken) {

            var allEpilepsyTypeCounts = await repository.ListAsync(new GetEpilepsyTypeCountsSpecification(), cancellationToken);

            var counts = allEpilepsyTypeCounts
            .GroupBy(mi => mi.EpilepsyTypeId)
            .Select(g => new { EpilepsyTypeId = g.Key, Count = g.Count() })
            .ToList();
            var result = new int[counts.Count, 2];
            for (int i = 0; i < counts.Count; i++) {
                result[i, 0] = counts[i].EpilepsyTypeId ?? 0;
                result[i, 1] = counts[i].Count;
            }

            return result;

        }
    }
}
