namespace Pineu.API.DTOs.MainDomain.Profiles {
    public sealed record UpdateProfileRequest(
        string? FullName,
        Gender? Gender,
        DateTime? Birthdate,
        MaritalStatus? MaritalStatus,
        string? PhoneNumber,
        Guid? DoctorId);
}
 