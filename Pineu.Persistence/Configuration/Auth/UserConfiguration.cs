namespace Pineu.Persistence.Configuration.Auth;

internal class UserConfiguration : IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder) {
        builder.ToTable(nameof(User));

        var user = new User {
            Id = Guid.Parse("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
            UserName = "admin",
            NormalizedUserName = "ADMIN",
        };
        var defaultUser = new User {
            Id = Guid.Parse("A1450D11-4A4E-402A-A94E-59D29BBA6F81"),
            UserName = "01234567410",
            NormalizedUserName = "01234567410",
            SecurityStamp = Guid.NewGuid().ToString(),
            IsActive = true,
        };

        PasswordHasher<User> ph = new();
        user.PasswordHash = ph.HashPassword(user, "`12qwe~!@QWE");
        defaultUser.PasswordHash = ph.HashPassword(defaultUser, "`12qwe~!@QWE");

        builder.HasData(
            new User {
                Id = user.Id,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = user.PasswordHash,
                LastName = "Admin",
                //Mobile = "",
                Email = "admin@admin.com",
                AccessFailedCount = 0,
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                //AvatarId = Guid.Parse("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                SecurityStamp = Guid.NewGuid().ToString(),
                IsActive = true,
            },
            defaultUser);

    }
}