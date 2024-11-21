using Pineu.Persistence.Specifications.MainDomain.MedicalInformations;

namespace Pineu.Persistence.Repositories.MainDomain {
    public class MedicalInformationRepository(IRepository<MedicalInformation, Guid> repository) : IMedicalInformationRepository {
        public async Task AddAsync(MedicalInformation medicalInformation, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(medicalInformation, cancellationToken);

        public async Task<MedicalInformation?> GetAsync(Guid userId, CancellationToken cancellationToken = default) =>
            await repository.FirstOrDefaultAsync(new GetMedicalInformationByIdSpecification(userId), cancellationToken);

        public async Task UpdateAsync(MedicalInformation medicalInformation, CancellationToken cancellationToken = default) =>
            await repository.UpdateAsync(medicalInformation, cancellationToken);
    }
}
