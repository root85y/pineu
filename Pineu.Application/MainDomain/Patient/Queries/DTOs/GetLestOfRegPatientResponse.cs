namespace Pineu.Application.MainDomain.Profiles.Queries.DTOs;

public sealed record GetLestOfRegPatientResponse(
    string? FullName,
    string? PhoneNumber,
    DateTime? Create
    );
