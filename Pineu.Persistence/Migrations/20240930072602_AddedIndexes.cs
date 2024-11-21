using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutStatus_Date",
                table: "WorkoutStatus",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutStatus_UserId",
                table: "WorkoutStatus",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMedicine_UserId",
                table: "UserMedicine",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIngredient_UserId",
                table: "UserIngredient",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SleepStatus_Date",
                table: "SleepStatus",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_SleepStatus_UserId",
                table: "SleepStatus",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Seizure_SeizureDateTime",
                table: "Seizure",
                column: "SeizureDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Seizure_UserId",
                table: "Seizure",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionStatus_Date",
                table: "NutritionStatus",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionStatus_UserId",
                table: "NutritionStatus",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MentalStatus_Date",
                table: "MentalStatus",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_MentalStatus_UserId",
                table: "MentalStatus",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformation_UserId",
                table: "MedicalInformation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPrescription_UserId",
                table: "DoctorPrescription",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkoutStatus_Date",
                table: "WorkoutStatus");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutStatus_UserId",
                table: "WorkoutStatus");

            migrationBuilder.DropIndex(
                name: "IX_UserMedicine_UserId",
                table: "UserMedicine");

            migrationBuilder.DropIndex(
                name: "IX_UserIngredient_UserId",
                table: "UserIngredient");

            migrationBuilder.DropIndex(
                name: "IX_SleepStatus_Date",
                table: "SleepStatus");

            migrationBuilder.DropIndex(
                name: "IX_SleepStatus_UserId",
                table: "SleepStatus");

            migrationBuilder.DropIndex(
                name: "IX_Seizure_SeizureDateTime",
                table: "Seizure");

            migrationBuilder.DropIndex(
                name: "IX_Seizure_UserId",
                table: "Seizure");

            migrationBuilder.DropIndex(
                name: "IX_NutritionStatus_Date",
                table: "NutritionStatus");

            migrationBuilder.DropIndex(
                name: "IX_NutritionStatus_UserId",
                table: "NutritionStatus");

            migrationBuilder.DropIndex(
                name: "IX_MentalStatus_Date",
                table: "MentalStatus");

            migrationBuilder.DropIndex(
                name: "IX_MentalStatus_UserId",
                table: "MentalStatus");

            migrationBuilder.DropIndex(
                name: "IX_MedicalInformation_UserId",
                table: "MedicalInformation");

            migrationBuilder.DropIndex(
                name: "IX_DoctorPrescription_UserId",
                table: "DoctorPrescription");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "6f17a715-61f9-45ae-881c-3e1277cf21ef", new DateTime(2024, 9, 26, 16, 15, 16, 469, DateTimeKind.Local).AddTicks(9775), "AQAAAAIAAYagAAAAEOgOwdRj3tVL5lwPe9L8/ZKCIbaMeONINZTEMUWSX/8YuN9VfqDPVPwycWZ0ohJLlA==", "65ccfc27-703d-4768-ab36-90c5796f7fd5", new DateTime(2024, 9, 26, 16, 15, 16, 469, DateTimeKind.Local).AddTicks(9776) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "a7f9c5d7-0b13-4e64-b629-98f1558a4ce9", new DateTime(2024, 9, 26, 16, 15, 16, 557, DateTimeKind.Local).AddTicks(9805), "AQAAAAIAAYagAAAAEB0rfMcUrdsrfU0eBH3+O9tdm8nESyjKG/+PsGFI3/STgDjRdzVYfhBJvuBO9l+slQ==", "76c8be98-2013-4c11-a1fe-303959be6d92", new DateTime(2024, 9, 26, 16, 15, 16, 557, DateTimeKind.Local).AddTicks(9818) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 26, 16, 15, 16, 689, DateTimeKind.Local).AddTicks(4079), new DateTime(2024, 9, 26, 16, 15, 16, 689, DateTimeKind.Local).AddTicks(4089) });
        }
    }
}
