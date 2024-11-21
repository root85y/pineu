namespace Pineu.Domain.Repositories.MainDomain;
public interface IMedicalInformationRepository {
    Task UpdateAsync(MedicalInformation medicalInformation, CancellationToken cancellationToken = default);
    Task AddAsync(MedicalInformation medicalInformation, CancellationToken cancellationToken = default);
    Task<MedicalInformation?> GetAsync(Guid userId, CancellationToken cancellationToken = default);
}
