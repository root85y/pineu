namespace Pineu.Application.MainDomain.Patient.Queries.DTOs;

public sealed record GetFullProfileResponse(
    Guid userId,
    string? fullName,
    Gender? gender,
    DateTime? birthdate,
    MaritalStatus? maritalStatus,
    string Mobile,
    Guid? doctorId,
    string status
  );

