﻿using Pineu.Domain.Entities.MainDomain;
using Pineu.Persistence.Specifications.MainDomain.Doctor;
using Pineu.Persistence.Specifications.MainDomain.Profiles;
using Pineu.Persistence.Specifications.MainDomain.Seizures;

namespace Pineu.Persistence.Repositories.MainDomain {
    public class ProfileRepository(IRepository<Profile, Guid> repository) : IProfileRepository {
        public async Task AddAsync(Profile profile, CancellationToken cancellationToken = default) =>
            await repository.AddAsync(profile, cancellationToken);

        public async Task<Profile?> GetAsync(Guid userId, CancellationToken cancellationToken = default) =>
            await repository.FirstOrDefaultAsync(new GetProfileByUserIdSpecification(userId), cancellationToken);

        public async Task<Profile?> GetWithPhoneAsync(string PhoneNumber, CancellationToken cancellationToken = default) =>
            await repository.FirstOrDefaultAsync(new GetProfileByPhoneNumberSpecification(PhoneNumber), cancellationToken);

        public async Task<PagedResponse<IEnumerable<Profile>>> GetWithDoctorIdAndPatientStatusAsync(Guid DoctorID, string PatientStatus, CancellationToken cancellationToken = default) {
            var specification = new GetProfileByDoctorIdAndstatusSpecification(DoctorID, PatientStatus);
            var totalItems = await repository.CountAsync(specification, cancellationToken);
            var profiles = await repository.ListAsync(specification, cancellationToken);

            return new PagedResponse<IEnumerable<Profile>>(profiles, totalItems);
        }

        public async Task<Profile?> GetFullProfileAsync(Guid PatientID, Guid doctorId, CancellationToken cancellationToken = default) =>
            await repository.FirstOrDefaultAsync(new GetFullProfileWithPatientIDSpecification(PatientID, doctorId), cancellationToken);

        public async Task UpdateAsync(Profile profile, CancellationToken cancellationToken = default) =>
            await repository.UpdateAsync(profile, cancellationToken);


        public async Task<int> UserCountGetAsync(CancellationToken cancellationToken = default) {


            return await repository.CountAsync(new GetProfileCountSpecification(), cancellationToken);
        }

        public async Task<List<Profile>> GetAllUserDataAsync(CancellationToken cancellationToken = default) =>
            await repository.ListAsync(new GetAllUserDataSpecification(), cancellationToken);


        public async Task<PagedResponse<IEnumerable<Profile>>> GetAllPatientStatusAsync(string PatientStatus, CancellationToken cancellationToken = default) {
            var specification = new GetAllProfilestatusSpecification(PatientStatus);
            var totalItems = await repository.CountAsync(specification, cancellationToken);
            var profiles = await repository.ListAsync(specification, cancellationToken);

            return new PagedResponse<IEnumerable<Profile>>(profiles, totalItems);
        }

        public async Task<List<Profile>> GetAllUserNotRegisteredDataAsync(string Status, CancellationToken cancellationToken = default) =>
    await repository.ListAsync(new GetAllUserNotRegisteredDataSpecification(Status), cancellationToken);

    }
}
