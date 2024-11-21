namespace Pineu.Persistence.Configuration.Auth;

internal class RoleConfiguration : IEntityTypeConfiguration<Role> {
    public void Configure(EntityTypeBuilder<Role> builder) {
        builder.ToTable(nameof(Role));

        var role = new Role {
            Id = Guid.Parse(Role.AdminRoleId),
            Name = "Admin",
            NormalizedName = "ADMIN",
        };
        builder.HasData(role);
    }
}