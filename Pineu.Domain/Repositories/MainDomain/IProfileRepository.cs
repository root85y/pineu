﻿using Pineu.Domain.Entities.MainDomain;

namespace Pineu.Domain.Repositories.MainDomain;
public interface IProfileRepository {
    Task UpdateAsync(Profile profile, CancellationToken cancellationToken = default);
    Task AddAsync(Profile profile, CancellationToken cancellationToken = default);
    Task<Profile?> GetAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Profile?> GetWithPhoneAsync(string Phonenumber, CancellationToken cancellationToken = default);
    Task<PagedResponse<IEnumerable<Profile?>>> GetWithDoctorIdAndPatientStatusAsync(Guid DoctorID, string PatientStatus, CancellationToken cancellationToken = default);
    Task<PagedResponse<IEnumerable<Profile?>>> GetAllPatientStatusAsync(string PatientStatus, CancellationToken cancellationToken = default);
    Task<Profile?> GetFullProfileAsync(Guid PatientID, Guid doctorId, CancellationToken cancellationToken = default);

    Task<int> UserCountGetAsync(CancellationToken cancellationToken = default);
    Task<List<Profile>> GetAllUserDataAsync(CancellationToken cancellationToken = default);
    Task<List<Profile>> GetAllUserNotRegisteredDataAsync(string Status , CancellationToken cancellationToken = default);


}
