namespace Pineu.API.DTOs.Auth.Permissions {
    public sealed record ChangePasswordRequest(string OldPassword, string NewPassword);
}
