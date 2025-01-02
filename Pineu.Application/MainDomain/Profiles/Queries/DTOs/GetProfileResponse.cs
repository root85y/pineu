namespace Pineu.Application.MainDomain.Profiles.Queries.DTOs {
    public sealed record GetProfileResponse(
        Guid? UserID,
        string? FullName,
        Gender? Gender,
        DateTime? Birthdate,
        MaritalStatus? MaritalStatus,
        int Score,
        string status,
        string PhoneNumber);
}
