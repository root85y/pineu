namespace Pineu.API.DTOs.Auth.Users;

public sealed record EditRoleRequest(IEnumerable<Guid> Roles);