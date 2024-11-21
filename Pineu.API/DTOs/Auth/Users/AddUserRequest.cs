namespace Pineu.API.DTOs.Auth.Users {
    public sealed record AddUserRequest(
        string Username,
        string? FirstName,
        string LastName,
        string? Layout);
}
