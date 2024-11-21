namespace Pineu.API.DTOs.Auth {
    public sealed record ValidateCodeRequest(string PhoneNumber, int Code);
}
