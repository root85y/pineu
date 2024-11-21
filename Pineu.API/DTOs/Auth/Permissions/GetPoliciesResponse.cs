using Pineu.Persistence.Constants.Enums;

namespace Pineu.API.DTOs.Auth.Permissions {
    public sealed record GetPoliciesResponse(Policies Value, string Label);
}
