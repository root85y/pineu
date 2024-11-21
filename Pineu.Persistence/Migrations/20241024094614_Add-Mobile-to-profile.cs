using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMobiletoprofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Profile",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "2197bdba-f544-4b89-9fc8-fd7648a4449e", new DateTime(2024, 10, 24, 13, 16, 13, 973, DateTimeKind.Local).AddTicks(2655), "AQAAAAIAAYagAAAAEC43uSdGfqZ28zzV/lxOYzxq2Y43Rnj9tQEzD9NGQq2SzNsUTTj2/u3dy/Zic0RG7Q==", "933f313f-842a-4715-8fe0-c827303c5ed6", new DateTime(2024, 10, 24, 13, 16, 13, 973, DateTimeKind.Local).AddTicks(2655) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "3b1ad698-abd8-4601-815a-7065f1d61863", new DateTime(2024, 10, 24, 13, 16, 14, 54, DateTimeKind.Local).AddTicks(7374), "AQAAAAIAAYagAAAAEACtriOqYFgW/elCbz2miqSyBkqhJ2sjm/PUX5KtpHmbyUBjO14jU86ERixbEP/nAA==", "c607b1ac-1c9d-4bcc-99c9-a16f3ff8c897", new DateTime(2024, 10, 24, 13, 16, 14, 54, DateTimeKind.Local).AddTicks(7384) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 24, 13, 16, 14, 150, DateTimeKind.Local).AddTicks(4267), new DateTime(2024, 10, 24, 13, 16, 14, 150, DateTimeKind.Local).AddTicks(4275) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Profile");

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
    }
}
