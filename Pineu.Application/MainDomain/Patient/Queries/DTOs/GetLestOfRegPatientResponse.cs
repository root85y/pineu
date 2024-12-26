namespace Pineu.Application.MainDomain.Profiles.Queries.DTOs;

public sealed record GetLestOfRegPatientResponse(
    Guid patientid,
    string? FullName,
    string? PhoneNumber,
    DateTime? Birthdate,
    DateTime? Create
    );
