using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Addstatustoprofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Profile",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "e8b2c347-c4b2-429c-868a-65b4006becbe", new DateTime(2024, 10, 24, 11, 59, 55, 882, DateTimeKind.Local).AddTicks(5891), "AQAAAAIAAYagAAAAEMn/CNZ/qZ7PjOaHBI5WTPQQKluxidcbpE902HhWbvxc0SRpf5Mgeer6hjTTwV+U5g==", "123a6975-082f-4527-9e76-069f519b922e", new DateTime(2024, 10, 24, 11, 59, 55, 882, DateTimeKind.Local).AddTicks(5892) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "ea18b6da-8710-4026-bf54-701ba6464431", new DateTime(2024, 10, 24, 11, 59, 55, 965, DateTimeKind.Local).AddTicks(4999), "AQAAAAIAAYagAAAAEBMRXXDmkm+KnEajwJPmlORIgQHx6TpXwQDso1LR24k3jdzbcHWEjqnIYpYx7bAhCA==", "a7e13eaa-a912-4409-80df-edbe8e6205f6", new DateTime(2024, 10, 24, 11, 59, 55, 965, DateTimeKind.Local).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 24, 11, 59, 56, 48, DateTimeKind.Local).AddTicks(5723), new DateTime(2024, 10, 24, 11, 59, 56, 48, DateTimeKind.Local).AddTicks(5731) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Profile");

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
    }
}
