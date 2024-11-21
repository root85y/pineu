using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "83daa177-7697-42c9-8ef5-3fa38c0fc35d", new DateTime(2024, 10, 10, 12, 17, 11, 63, DateTimeKind.Local).AddTicks(5940), "AQAAAAIAAYagAAAAEP/Qh/jmNY/oI8QwalqhtjEltZWpgPoLMABvZ5/+empzYvPPgHkQdKWYlWivPTsGqA==", "337e9544-59fe-4a07-a2bc-cf156c4cd8a4", new DateTime(2024, 10, 10, 12, 17, 11, 63, DateTimeKind.Local).AddTicks(5940) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "c6ae1fac-cec0-4b17-941e-7dfb41598056", new DateTime(2024, 10, 10, 12, 17, 11, 147, DateTimeKind.Local).AddTicks(6646), "AQAAAAIAAYagAAAAEIKu5w1rWg4lTEyCDJFDMDhivFVMBcTDgoGi8CgvWwAxi85Xp7R2YfSrzOd1RAXcJQ==", "43392dce-37c6-4150-a1e7-9279e260d948", new DateTime(2024, 10, 10, 12, 17, 11, 147, DateTimeKind.Local).AddTicks(6663) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 10, 12, 17, 11, 233, DateTimeKind.Local).AddTicks(5890), new DateTime(2024, 10, 10, 12, 17, 11, 233, DateTimeKind.Local).AddTicks(5899) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "1379a3e8-0e29-4651-b0ba-7962fddbd778", new DateTime(2024, 9, 30, 10, 56, 2, 81, DateTimeKind.Local).AddTicks(9514), "AQAAAAIAAYagAAAAECft46NaJsb42QZcAIla3++o1WGHkbe6jwMuBwe3P8AtOUUBgSMLgvDD1MbXY+mUrg==", "a88704c8-1c7a-4369-887d-26d3a609506d", new DateTime(2024, 9, 30, 10, 56, 2, 81, DateTimeKind.Local).AddTicks(9514) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "82c6a625-8cb8-4a8b-9958-d86c72a749ec", new DateTime(2024, 9, 30, 10, 56, 2, 170, DateTimeKind.Local).AddTicks(5394), "AQAAAAIAAYagAAAAELiP8kqNeU0JDgDK5Cx9x9LIjG1MTbxEimWK3ayaG6fhn7pjIB7zWLrQDusQJxny2Q==", "d30cf426-17df-4f1b-9947-461724622cda", new DateTime(2024, 9, 30, 10, 56, 2, 170, DateTimeKind.Local).AddTicks(5408) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 30, 10, 56, 2, 293, DateTimeKind.Local).AddTicks(782), new DateTime(2024, 9, 30, 10, 56, 2, 293, DateTimeKind.Local).AddTicks(792) });
        }
    }
}
