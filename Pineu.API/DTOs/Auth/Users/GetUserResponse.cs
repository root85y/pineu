namespace Pineu.API.DTOs.Auth.Users {
    public sealed record GetUserResponse(Guid Id, string? FirstName, string LastName, string Username, bool IsActive);
}
