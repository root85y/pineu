namespace Pineu.API.DTOs.Auth.Permissions {
    public sealed record GetUserResponse(string Username, string FirstName, string LastName, DateTime CreatedAt);
}
