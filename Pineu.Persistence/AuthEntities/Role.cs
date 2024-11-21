namespace Pineu.Persistence.AuthEntities;

public class Role : IdentityRole<Guid> {
    public const string PermissionClaimSeparator = ":";
    public const string AdminRoleId = "37bb9548-71f3-4610-b41e-d31f11359848";
    public const string Test = "test";
    public static Dictionary<PermissionNames, List<Policies>> DefaultPermissions =
        new()
        {
            {PermissionNames.Role, [Policies.Read, Policies.Create, Policies.Update, Policies.Delete] },
            {PermissionNames.Permission, [Policies.Read] },
            {PermissionNames.User, [Policies.Read, Policies.Create, Policies.Update, Policies.Password, Policies.Role] },
            {PermissionNames.Database, [Policies.Backup, Policies.Read, Policies.Delete] }
        };

    public static string MakePolicy(PermissionNames permission, Policies policy) =>
        $"{(byte)permission}{PermissionClaimSeparator}{(byte)policy}";
}