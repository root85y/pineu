namespace Pineu.API.DTOs.MainDomain.Patient;

public sealed record PatientRegistrationRequest(
    string? FullName,
    string PhoneNumber
    );