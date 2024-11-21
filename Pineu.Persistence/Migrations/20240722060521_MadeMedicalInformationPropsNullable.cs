using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations {
    /// <inheritdoc />
    public partial class MadeMedicalInformationPropsNullable : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AlterColumn<string>(
                name: "SeizureSymptoms",
                table: "MedicalInformation",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SeizureInjuryList",
                table: "MedicalInformation",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "OtherDiseaseList",
                table: "MedicalInformation",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "MedicineList",
                table: "MedicalInformation",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<byte>(
                name: "EpilepsyType",
                table: "MedicalInformation",
                type: "tinyint unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DiagnosisDate",
                table: "MedicalInformation",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "9267fd80-7d68-48c4-a3dc-4be9bce9cc6f", new DateTime(2024, 7, 22, 9, 35, 20, 780, DateTimeKind.Local).AddTicks(2131), "AQAAAAIAAYagAAAAENrqkEurKfCvVc53odp+uFB7s8vnFEKnOvllrUP5Lz7gej86zltrGyvW4flOQwCcOg==", "f3f28f77-1cf6-4069-8ae0-5f41ec57cbe9", new DateTime(2024, 7, 22, 9, 35, 20, 780, DateTimeKind.Local).AddTicks(2132) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "fe6337e1-8f09-4c72-a2a0-e0df16bac357", new DateTime(2024, 7, 22, 9, 35, 20, 914, DateTimeKind.Local).AddTicks(4425), "AQAAAAIAAYagAAAAEChf1CD2LpjnAfxavgH0990HWZZtYAXeoNIoz26FtLIA91SqSAcEIcAejVh0sfubog==", "a406e4b9-493b-41eb-ad9d-62e37fad105f", new DateTime(2024, 7, 22, 9, 35, 20, 914, DateTimeKind.Local).AddTicks(4442) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 22, 9, 35, 20, 942, DateTimeKind.Local).AddTicks(5540), new DateTime(2024, 7, 22, 9, 35, 20, 942, DateTimeKind.Local).AddTicks(5553) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.UpdateData(
                table: "MedicalInformation",
                keyColumn: "SeizureSymptoms",
                keyValue: null,
                column: "SeizureSymptoms",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SeizureSymptoms",
                table: "MedicalInformation",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "MedicalInformation",
                keyColumn: "SeizureInjuryList",
                keyValue: null,
                column: "SeizureInjuryList",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SeizureInjuryList",
                table: "MedicalInformation",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "MedicalInformation",
                keyColumn: "OtherDiseaseList",
                keyValue: null,
                column: "OtherDiseaseList",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "OtherDiseaseList",
                table: "MedicalInformation",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "MedicalInformation",
                keyColumn: "MedicineList",
                keyValue: null,
                column: "MedicineList",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "MedicineList",
                table: "MedicalInformation",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<byte>(
                name: "EpilepsyType",
                table: "MedicalInformation",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DiagnosisDate",
                table: "MedicalInformation",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "63fb3bc0-c543-4dc4-8a6b-8ad7cac94ee4", new DateTime(2024, 7, 20, 14, 25, 28, 832, DateTimeKind.Local).AddTicks(3895), "AQAAAAIAAYagAAAAEEwXZFAmYXw3wBrh2byKZJYccHW486N6fPFtyM1wEZt+tyKVTwMF0gaAew2vBdYNuw==", "7957f97d-c9ec-428a-927d-4bbb91e9fa1e", new DateTime(2024, 7, 20, 14, 25, 28, 832, DateTimeKind.Local).AddTicks(3896) });

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
    }
}
