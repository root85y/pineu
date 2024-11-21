using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUserMedicineTypeToNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "UserMedicine",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "f294b946-2329-4b72-b4a7-c0d614cb33cd", new DateTime(2024, 8, 31, 10, 45, 6, 281, DateTimeKind.Local).AddTicks(5219), "AQAAAAIAAYagAAAAEC9DRudcxxNeS4M19vLWwPybmafEhjKNS1oSd8JuzgYu2bpAmIazEZk//JgKkPPW5A==", "592ffae8-0f0e-4c12-9874-bc0903b183c1", new DateTime(2024, 8, 31, 10, 45, 6, 281, DateTimeKind.Local).AddTicks(5219) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "d1181fa3-eaa8-4444-9fea-7ddc17fcbcdf", new DateTime(2024, 8, 31, 10, 45, 6, 368, DateTimeKind.Local).AddTicks(4348), "AQAAAAIAAYagAAAAENVuoNVkQwCW36ZIn9gPKaJ6Gi0TkwqlugsZsVcvZk7u0YKXaoKg297VLV55iKxH/g==", "d824926b-bba3-4826-a32d-fd85247d6d62", new DateTime(2024, 8, 31, 10, 45, 6, 368, DateTimeKind.Local).AddTicks(4361) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 31, 10, 45, 6, 388, DateTimeKind.Local).AddTicks(2175), new DateTime(2024, 8, 31, 10, 45, 6, 388, DateTimeKind.Local).AddTicks(2184) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "UserMedicine",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "a967dd42-dd95-4bf8-bbcf-a41dceae1f59", new DateTime(2024, 8, 24, 17, 6, 55, 534, DateTimeKind.Local).AddTicks(3055), "AQAAAAIAAYagAAAAEHDEw0ZRdM62nLPRQU15ydRB2kjeQ3vibr8ySzGD0SsiP5/adbJS3N6XkbqARVUzvA==", "3f31f236-7c3b-4e73-8917-87f606c0ec71", new DateTime(2024, 8, 24, 17, 6, 55, 534, DateTimeKind.Local).AddTicks(3056) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "6362c3df-bb00-47c4-94a7-548692a29e6f", new DateTime(2024, 8, 24, 17, 6, 55, 618, DateTimeKind.Local).AddTicks(7347), "AQAAAAIAAYagAAAAEKyGvbC+nFUkzEI0MEDn12iYZrgq4mirz+QaqUUBzkSHsgGEV0JJQ7751htbeYGvfw==", "64f820c6-0515-40ca-a7b5-04eb7c473396", new DateTime(2024, 8, 24, 17, 6, 55, 618, DateTimeKind.Local).AddTicks(7361) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 17, 6, 55, 636, DateTimeKind.Local).AddTicks(3795), new DateTime(2024, 8, 24, 17, 6, 55, 636, DateTimeKind.Local).AddTicks(3801) });
        }
    }
}
