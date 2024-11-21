using Pineu.Persistence.Constants.Enums;

namespace Pineu.API.DTOs.Auth.Permissions {
    public sealed record GetPermissionsResponse(PermissionNames Value, string Label, IEnumerable<GetPoliciesResponse> Policies);
}
