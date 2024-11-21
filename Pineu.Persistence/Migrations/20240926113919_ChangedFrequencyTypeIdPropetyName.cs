using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedFrequencyTypeIdPropetyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformation_DateTimeUnitType_FrequencyTypeId",
                table: "MedicalInformation");

            migrationBuilder.RenameColumn(
                name: "SeizureSymptomsFrequency",
                table: "MedicalInformation",
                newName: "SeizureSymptomFrequency");

            migrationBuilder.RenameColumn(
                name: "FrequencyTypeId",
                table: "MedicalInformation",
                newName: "SeizureSymptomFrequencyTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalInformation_FrequencyTypeId",
                table: "MedicalInformation",
                newName: "IX_MedicalInformation_SeizureSymptomFrequencyTypeId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "cfbcc873-e03d-4d01-bdfb-49b8308b4e08", new DateTime(2024, 9, 26, 15, 9, 19, 70, DateTimeKind.Local).AddTicks(9690), "AQAAAAIAAYagAAAAEAxOGFrrUDdm9xbvwV3iYfBrVHC8BujAoIAF7QCTZ1Z2/gtICESZTa4AHecOiiRCWQ==", "8b2a88a1-5ad3-4714-a5b8-8682032db5a8", new DateTime(2024, 9, 26, 15, 9, 19, 70, DateTimeKind.Local).AddTicks(9691) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "7494ede0-2e22-43b6-8df6-3733f5e0fabd", new DateTime(2024, 9, 26, 15, 9, 19, 157, DateTimeKind.Local).AddTicks(5760), "AQAAAAIAAYagAAAAEOUF89HvrsL31Ca9XWAk3uSyN2XVccEtpBiwncCe4IuJKlxQoa9+lscz25F74aYeNQ==", "d935ca16-2e98-41cf-b732-8c6211d27f5d", new DateTime(2024, 9, 26, 15, 9, 19, 157, DateTimeKind.Local).AddTicks(5770) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 26, 15, 9, 19, 275, DateTimeKind.Local).AddTicks(5635), new DateTime(2024, 9, 26, 15, 9, 19, 275, DateTimeKind.Local).AddTicks(5647) });

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformation_DateTimeUnitType_SeizureSymptomFrequencyT~",
                table: "MedicalInformation",
                column: "SeizureSymptomFrequencyTypeId",
                principalTable: "DateTimeUnitType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformation_DateTimeUnitType_SeizureSymptomFrequencyT~",
                table: "MedicalInformation");

            migrationBuilder.RenameColumn(
                name: "SeizureSymptomFrequencyTypeId",
                table: "MedicalInformation",
                newName: "FrequencyTypeId");

            migrationBuilder.RenameColumn(
                name: "SeizureSymptomFrequency",
                table: "MedicalInformation",
                newName: "SeizureSymptomsFrequency");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalInformation_SeizureSymptomFrequencyTypeId",
                table: "MedicalInformation",
                newName: "IX_MedicalInformation_FrequencyTypeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformation_DateTimeUnitType_FrequencyTypeId",
                table: "MedicalInformation",
                column: "FrequencyTypeId",
                principalTable: "DateTimeUnitType",
                principalColumn: "Id");
        }
    }
}
