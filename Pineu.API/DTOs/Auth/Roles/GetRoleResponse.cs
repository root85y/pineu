using Pineu.Persistence.Constants.Enums;

namespace Pineu.API.DTOs.Auth.Roles {
    public sealed record GetRoleResponse(Guid Id, string Name, IDictionary<PermissionNames, List<Policies>> Permissions);
}
