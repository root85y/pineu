using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedPhotoResultAndEditedPhotoDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoResult",
                table: "MedicalInformation",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateOnly>(
                name: "PhotoDate",
                table: "MedicalInformation",
                type: "date",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "608325f4-7d33-4ea0-85e1-3cc22ca619d8", new DateTime(2024, 9, 26, 12, 11, 43, 784, DateTimeKind.Local).AddTicks(313), "AQAAAAIAAYagAAAAEGEnLSvUOVywrKibPKYI1DoioqJyIi7ROuahKnX/9UVmVPRm+chD9SQLhfUmbJZSuQ==", "f19fe275-3a0a-446a-9128-b7a115905962", new DateTime(2024, 9, 26, 12, 11, 43, 784, DateTimeKind.Local).AddTicks(314) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "496f0522-acf8-41f0-bb78-99ac2b52f717", new DateTime(2024, 9, 26, 12, 11, 43, 872, DateTimeKind.Local).AddTicks(601), "AQAAAAIAAYagAAAAEE7eTv33MnXojUTelqWn6OWwN7BnbopPOLk66pTMJG4EXdISjwAVAkLHRmXoj90LSQ==", "d1d0b6a9-e23d-4b57-8be7-48e3d45df1c3", new DateTime(2024, 9, 26, 12, 11, 43, 872, DateTimeKind.Local).AddTicks(612) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 26, 12, 11, 43, 987, DateTimeKind.Local).AddTicks(386), new DateTime(2024, 9, 26, 12, 11, 43, 987, DateTimeKind.Local).AddTicks(395) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoDate",
                table: "MedicalInformation");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "PhotoResult",
                table: "MedicalInformation",
                type: "date",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "b4579a16-eebb-42e4-974a-47e37d917e1c", new DateTime(2024, 9, 23, 15, 32, 6, 367, DateTimeKind.Local).AddTicks(5684), "AQAAAAIAAYagAAAAEMaXEJSG5+wdTBEviKiiOZntYSBd/diHIzOUx+VmUeGgY7YvMVVZ5RznNyf1IAr9Yw==", "5091cbb3-eee9-4cc0-86dc-93fc91958ef5", new DateTime(2024, 9, 23, 15, 32, 6, 367, DateTimeKind.Local).AddTicks(5684) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "3f3202d8-2c5c-48bf-93b3-0a03023729c3", new DateTime(2024, 9, 23, 15, 32, 6, 454, DateTimeKind.Local).AddTicks(4014), "AQAAAAIAAYagAAAAEHAe4AAjmj3fYrqfD3lWc6rpExjRibg1QXibLjtMPv6i/rRIXp2qFTXSypYn5XUuiA==", "84bd384c-cc10-4f65-b5f4-f81e2eafa238", new DateTime(2024, 9, 23, 15, 32, 6, 454, DateTimeKind.Local).AddTicks(4027) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 23, 15, 32, 6, 579, DateTimeKind.Local).AddTicks(3148), new DateTime(2024, 9, 23, 15, 32, 6, 579, DateTimeKind.Local).AddTicks(3157) });
        }
    }
}
