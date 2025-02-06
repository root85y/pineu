using Pineu.Persistence.Specifications.MainDomain.Doctor;
using Pineu.Persistence.Specifications.MainDomain.Profiles;

namespace Pineu.Persistence.Repositories.MainDomain {
    public class DoctorRepository(IRepository<Doctor, Guid> repository) : IDoctorRepository {
        public async Task AddAsync(Doctor doctor, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(doctor, cancellationToken);

        public async Task<Doctor?> GetAsync(Guid userId, CancellationToken cancellationToken = default) =>
            await repository.FirstOrDefaultAsync(new GetDoctorByUserIdSpecification(userId), cancellationToken);

        public async Task UpdateAsync(Doctor doctor, CancellationToken cancellationToken = default) =>
            await repository.UpdateAsync(doctor, cancellationToken);

        public async Task<int> UserCountGetAsync(CancellationToken cancellationToken = default) {

            return await repository.CountAsync(new GetDoctorCountSpecification(), cancellationToken);
        }

        public async Task<List<Doctor>> GetAllDoctorDataAsync(CancellationToken cancellationToken = default) =>
            await repository.ListAsync(new GetAllDoctorDataSpecification(), cancellationToken);
    }
}
