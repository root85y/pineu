using Pineu.Persistence.Constants.Enums;

namespace Pineu.API.DTOs.Auth.Roles {
    public sealed record AddRoleRequest(string Name, IDictionary<PermissionNames, IEnumerable<Policies>> Permissions);
}
