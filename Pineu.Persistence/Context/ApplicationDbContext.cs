using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Shared.Constants;
using System.Security.Claims;
using Microsoft.Extensions.Logging;

namespace Pineu.Persistence.Context {
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid> {
        public ApplicationDbContext() {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }
        private static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(DBSettings.ApplicationDbContextConnectionString,
                    ServerVersion.AutoDetect(DBSettings.ApplicationDbContextConnectionString))
                .UseLoggerFactory(MyLoggerFactory);
            base.OnConfiguring(optionsBuilder);
        }

        public static async Task SeedAdminDefaultPermissionsAsync(RoleManager<Role> roleManager) {
            var permissionsList = new List<string>();
            foreach (var (permissionName, policiesList) in Role.DefaultPermissions)
                foreach (var policy in policiesList)
                    permissionsList.Add($"{permissionName}{Role.PermissionClaimSeparator}{policy}");
            var role = (await roleManager.FindByIdAsync(Role.AdminRoleId))!;
            var currentClaims = await roleManager.GetClaimsAsync(role);
            foreach (var c in currentClaims.Where(c => !permissionsList.Contains(c.Type)))
                await roleManager.RemoveClaimAsync(role, c);

            foreach (var permission in permissionsList.Where(p => currentClaims.All(c => c.Type != p)))
                await roleManager.AddClaimAsync(role, new Claim(permission, permission));
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

            SeedData(builder);

            base.OnModelCreating(builder);
        }

        private void SeedData(ModelBuilder builder) {
            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid> {
                    RoleId = Guid.Parse(Role.AdminRoleId),
                    UserId = Guid.Parse("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0")
                }
            );
        }
    }
}
