
namespace Pineu.API.DTOs.Auth.Permissions {
    public sealed record RegisterRequest(
        string? NationalCode, 
        string MedicalSystemCode, 
        string PhoneNumber,
        int? Code,
        string? Password
        );
}
