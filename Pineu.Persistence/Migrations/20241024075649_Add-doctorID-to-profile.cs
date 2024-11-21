using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdddoctorIDtoprofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                table: "Profile",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "08e7d769-e503-42e1-8355-db0d189980d6", new DateTime(2024, 10, 24, 11, 26, 49, 180, DateTimeKind.Local).AddTicks(5560), "AQAAAAIAAYagAAAAEOdQ6sO9Q74ehlicdj6r8NU+VC1d0XzPn16nDetYjsHlpajyMBxp95O7v7eCOPcRig==", "9685d7af-c3c1-4a19-a1e7-1d3a4f2b17cf", new DateTime(2024, 10, 24, 11, 26, 49, 180, DateTimeKind.Local).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "e421c210-9507-44b3-b009-8fdc90a9511a", new DateTime(2024, 10, 24, 11, 26, 49, 261, DateTimeKind.Local).AddTicks(4782), "AQAAAAIAAYagAAAAEJ35J9mNYRObsHlXczw2w0xI4W7Ciu7LOihay2Dl1hd8jbAlxdRJa9lljPNEPjTBYQ==", "531906d8-fc85-4f38-9515-f48162683bca", new DateTime(2024, 10, 24, 11, 26, 49, 261, DateTimeKind.Local).AddTicks(4792) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 24, 11, 26, 49, 359, DateTimeKind.Local).AddTicks(4898), new DateTime(2024, 10, 24, 11, 26, 49, 359, DateTimeKind.Local).AddTicks(4907) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Profile");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "4ef34d53-d030-4068-baf2-6613f78ede03", new DateTime(2024, 10, 22, 16, 34, 25, 764, DateTimeKind.Local).AddTicks(8474), "AQAAAAIAAYagAAAAEPWnOiGh501PW1sM9hi/hu4BGTZEj79r0L5W0O1VNK1ugB20BLWkWahug2k0LroH0g==", "d21d9aab-d463-4f77-b31c-c76af4ddb4e9", new DateTime(2024, 10, 22, 16, 34, 25, 764, DateTimeKind.Local).AddTicks(8474) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "61fbc94c-bd21-49e6-94a7-099d7bb3ef39", new DateTime(2024, 10, 22, 16, 34, 25, 845, DateTimeKind.Local).AddTicks(1637), "AQAAAAIAAYagAAAAELHD68grAkNMidbIl5La98ViUqdSNWEbABXINoYm5sG8EI+kH0LYj1+NyqSt1HfS9g==", "726df8c8-780a-4a46-b4d6-36a82606d747", new DateTime(2024, 10, 22, 16, 34, 25, 845, DateTimeKind.Local).AddTicks(1649) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 22, 16, 34, 25, 940, DateTimeKind.Local).AddTicks(5415), new DateTime(2024, 10, 22, 16, 34, 25, 940, DateTimeKind.Local).AddTicks(5422) });
        }
    }
}
