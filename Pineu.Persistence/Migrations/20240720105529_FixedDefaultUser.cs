using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations {
    /// <inheritdoc />
    public partial class FixedDefaultUser : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "63fb3bc0-c543-4dc4-8a6b-8ad7cac94ee4", new DateTime(2024, 7, 20, 14, 25, 28, 832, DateTimeKind.Local).AddTicks(3895), "01234567410", "AQAAAAIAAYagAAAAEEwXZFAmYXw3wBrh2byKZJYccHW486N6fPFtyM1wEZt+tyKVTwMF0gaAew2vBdYNuw==", "7957f97d-c9ec-428a-927d-4bbb91e9fa1e", new DateTime(2024, 7, 20, 14, 25, 28, 832, DateTimeKind.Local).AddTicks(3896) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "81258363-d53e-40a5-ac5f-9802f55fed0c", new DateTime(2024, 7, 20, 14, 25, 28, 966, DateTimeKind.Local).AddTicks(6288), "AQAAAAIAAYagAAAAEFWgrwMRH6hPDrAvnJG0HZtVts8jnQoCA9HBWLzrxV5oFLM/0svr4/q5xA1t7FV+NA==", "f1da2433-70f0-4f7c-b6df-8faddb9ae48e", new DateTime(2024, 7, 20, 14, 25, 28, 966, DateTimeKind.Local).AddTicks(6304) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 20, 14, 25, 28, 992, DateTimeKind.Local).AddTicks(286), new DateTime(2024, 7, 20, 14, 25, 28, 992, DateTimeKind.Local).AddTicks(301) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "fd232f34-4b0a-422c-a7c5-28ff9140670e", new DateTime(2024, 7, 20, 14, 18, 46, 428, DateTimeKind.Local).AddTicks(4932), null, "AQAAAAIAAYagAAAAEAgmVRPa/gsg1kxhNfSqyQ2KJmfE+ZwC8vtBrjHt01CkWJKjp6KXNQlopScgqht2ew==", null, new DateTime(2024, 7, 20, 14, 18, 46, 428, DateTimeKind.Local).AddTicks(4932) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "959af58d-f4dd-4dbd-8553-ce62d28c2535", new DateTime(2024, 7, 20, 14, 18, 46, 567, DateTimeKind.Local).AddTicks(3307), "AQAAAAIAAYagAAAAEFaw6Mh7byaGRx5G3/sBHvj+oLcP0Q/8pksyPGQBctqgdmScf4M8hX8hPH2zLiaf6Q==", "ccf37117-c7c1-47e0-ae4d-b2d98280ee07", new DateTime(2024, 7, 20, 14, 18, 46, 567, DateTimeKind.Local).AddTicks(3323) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 20, 14, 18, 46, 597, DateTimeKind.Local).AddTicks(1328), new DateTime(2024, 7, 20, 14, 18, 46, 597, DateTimeKind.Local).AddTicks(1344) });
        }
    }
}
