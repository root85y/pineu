using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations {
    /// <inheritdoc />
    public partial class AddedDefaultUser : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "959af58d-f4dd-4dbd-8553-ce62d28c2535", new DateTime(2024, 7, 20, 14, 18, 46, 567, DateTimeKind.Local).AddTicks(3307), "AQAAAAIAAYagAAAAEFaw6Mh7byaGRx5G3/sBHvj+oLcP0Q/8pksyPGQBctqgdmScf4M8hX8hPH2zLiaf6Q==", "ccf37117-c7c1-47e0-ae4d-b2d98280ee07", new DateTime(2024, 7, 20, 14, 18, 46, 567, DateTimeKind.Local).AddTicks(3323) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RemovedAt", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"), 0, "fd232f34-4b0a-422c-a7c5-28ff9140670e", new DateTime(2024, 7, 20, 14, 18, 46, 428, DateTimeKind.Local).AddTicks(4932), null, false, null, true, null, false, null, null, null, "AQAAAAIAAYagAAAAEAgmVRPa/gsg1kxhNfSqyQ2KJmfE+ZwC8vtBrjHt01CkWJKjp6KXNQlopScgqht2ew==", null, false, null, null, false, new DateTime(2024, 7, 20, 14, 18, 46, 428, DateTimeKind.Local).AddTicks(4932), "01234567410" });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 20, 14, 18, 46, 597, DateTimeKind.Local).AddTicks(1328), new DateTime(2024, 7, 20, 14, 18, 46, 597, DateTimeKind.Local).AddTicks(1344) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "b5ba5664-6888-4bc9-a37f-1d66d0270206", new DateTime(2024, 7, 17, 15, 46, 9, 730, DateTimeKind.Local).AddTicks(5414), "AQAAAAIAAYagAAAAEAey5TNpQIZhrzAPCkuSFqxBCQKuljl4k21tUyfsWvKpoUadqYaK/s9ebYTbQBV88A==", "d7a1d82b-66ff-4aa9-ba2b-b778f7ae128d", new DateTime(2024, 7, 17, 15, 46, 9, 730, DateTimeKind.Local).AddTicks(5423) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 15, 46, 9, 754, DateTimeKind.Local).AddTicks(5746), new DateTime(2024, 7, 17, 15, 46, 9, 754, DateTimeKind.Local).AddTicks(5756) });
        }
    }
}
