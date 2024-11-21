using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MadeMedicalEntitiesPropertiesNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrentAntiepilepticMedicine_DateTimeUnitType_DateTimeUnitTy~",
                table: "CurrentAntiepilepticMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentAntiepilepticMedicine_DurationOfUseType_DurationOfUse~",
                table: "CurrentAntiepilepticMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_DrugConsumption_DateTimeUnitType_DateTimeUnitTypeId",
                table: "DrugConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherMedicine_DateTimeUnitType_DateTimeUnitTypeId",
                table: "OtherMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherMedicine_DurationOfUseType_DurationOfUseTypeId",
                table: "OtherMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_PastAntiepilepticMedicine_DateTimeUnitType_DateTimeUnitTypeId",
                table: "PastAntiepilepticMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_PastAntiepilepticMedicine_DurationOfUseType_DurationOfUseTyp~",
                table: "PastAntiepilepticMedicine");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "StopDate",
                table: "PastAntiepilepticMedicine",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "ReasonOfStop",
                table: "PastAntiepilepticMedicine",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<short>(
                name: "DurationOfUseTypeId",
                table: "PastAntiepilepticMedicine",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<short>(
                name: "DateTimeUnitTypeId",
                table: "PastAntiepilepticMedicine",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "PastAntiepilepticMedicine",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "DurationOfUseTypeId",
                table: "OtherMedicine",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<short>(
                name: "DateTimeUnitTypeId",
                table: "OtherMedicine",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "Complications",
                table: "OtherMedicine",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "OtherMedicine",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Relationship",
                table: "FamilyDiseaseHistory",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FamilyDiseaseHistory",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "DrugConsumptionDuration",
                table: "DrugConsumption",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "DateTimeUnitTypeId",
                table: "DrugConsumption",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "DailyAmount",
                table: "DrugConsumption",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "DurationOfUseTypeId",
                table: "CurrentAntiepilepticMedicine",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<short>(
                name: "DateTimeUnitTypeId",
                table: "CurrentAntiepilepticMedicine",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "Complications",
                table: "CurrentAntiepilepticMedicine",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "CurrentAntiepilepticMedicine",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentAntiepilepticMedicine_DateTimeUnitType_DateTimeUnitTy~",
                table: "CurrentAntiepilepticMedicine",
                column: "DateTimeUnitTypeId",
                principalTable: "DateTimeUnitType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentAntiepilepticMedicine_DurationOfUseType_DurationOfUse~",
                table: "CurrentAntiepilepticMedicine",
                column: "DurationOfUseTypeId",
                principalTable: "DurationOfUseType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DrugConsumption_DateTimeUnitType_DateTimeUnitTypeId",
                table: "DrugConsumption",
                column: "DateTimeUnitTypeId",
                principalTable: "DateTimeUnitType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherMedicine_DateTimeUnitType_DateTimeUnitTypeId",
                table: "OtherMedicine",
                column: "DateTimeUnitTypeId",
                principalTable: "DateTimeUnitType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherMedicine_DurationOfUseType_DurationOfUseTypeId",
                table: "OtherMedicine",
                column: "DurationOfUseTypeId",
                principalTable: "DurationOfUseType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PastAntiepilepticMedicine_DateTimeUnitType_DateTimeUnitTypeId",
                table: "PastAntiepilepticMedicine",
                column: "DateTimeUnitTypeId",
                principalTable: "DateTimeUnitType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PastAntiepilepticMedicine_DurationOfUseType_DurationOfUseTyp~",
                table: "PastAntiepilepticMedicine",
                column: "DurationOfUseTypeId",
                principalTable: "DurationOfUseType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrentAntiepilepticMedicine_DateTimeUnitType_DateTimeUnitTy~",
                table: "CurrentAntiepilepticMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentAntiepilepticMedicine_DurationOfUseType_DurationOfUse~",
                table: "CurrentAntiepilepticMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_DrugConsumption_DateTimeUnitType_DateTimeUnitTypeId",
                table: "DrugConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherMedicine_DateTimeUnitType_DateTimeUnitTypeId",
                table: "OtherMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherMedicine_DurationOfUseType_DurationOfUseTypeId",
                table: "OtherMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_PastAntiepilepticMedicine_DateTimeUnitType_DateTimeUnitTypeId",
                table: "PastAntiepilepticMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_PastAntiepilepticMedicine_DurationOfUseType_DurationOfUseTyp~",
                table: "PastAntiepilepticMedicine");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "StopDate",
                table: "PastAntiepilepticMedicine",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "PastAntiepilepticMedicine",
                keyColumn: "ReasonOfStop",
                keyValue: null,
                column: "ReasonOfStop",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ReasonOfStop",
                table: "PastAntiepilepticMedicine",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<short>(
                name: "DurationOfUseTypeId",
                table: "PastAntiepilepticMedicine",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "DateTimeUnitTypeId",
                table: "PastAntiepilepticMedicine",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "PastAntiepilepticMedicine",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "DurationOfUseTypeId",
                table: "OtherMedicine",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "DateTimeUnitTypeId",
                table: "OtherMedicine",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "OtherMedicine",
                keyColumn: "Complications",
                keyValue: null,
                column: "Complications",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Complications",
                table: "OtherMedicine",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "OtherMedicine",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "FamilyDiseaseHistory",
                keyColumn: "Relationship",
                keyValue: null,
                column: "Relationship",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Relationship",
                table: "FamilyDiseaseHistory",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "FamilyDiseaseHistory",
                keyColumn: "Name",
                keyValue: null,
                column: "Name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FamilyDiseaseHistory",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "DrugConsumptionDuration",
                table: "DrugConsumption",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "DateTimeUnitTypeId",
                table: "DrugConsumption",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DailyAmount",
                table: "DrugConsumption",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "DurationOfUseTypeId",
                table: "CurrentAntiepilepticMedicine",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "DateTimeUnitTypeId",
                table: "CurrentAntiepilepticMedicine",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CurrentAntiepilepticMedicine",
                keyColumn: "Complications",
                keyValue: null,
                column: "Complications",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Complications",
                table: "CurrentAntiepilepticMedicine",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "CurrentAntiepilepticMedicine",
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
                name: "FK_CurrentAntiepilepticMedicine_DateTimeUnitType_DateTimeUnitTy~",
                table: "CurrentAntiepilepticMedicine",
                column: "DateTimeUnitTypeId",
                principalTable: "DateTimeUnitType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentAntiepilepticMedicine_DurationOfUseType_DurationOfUse~",
                table: "CurrentAntiepilepticMedicine",
                column: "DurationOfUseTypeId",
                principalTable: "DurationOfUseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrugConsumption_DateTimeUnitType_DateTimeUnitTypeId",
                table: "DrugConsumption",
                column: "DateTimeUnitTypeId",
                principalTable: "DateTimeUnitType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherMedicine_DateTimeUnitType_DateTimeUnitTypeId",
                table: "OtherMedicine",
                column: "DateTimeUnitTypeId",
                principalTable: "DateTimeUnitType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherMedicine_DurationOfUseType_DurationOfUseTypeId",
                table: "OtherMedicine",
                column: "DurationOfUseTypeId",
                principalTable: "DurationOfUseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PastAntiepilepticMedicine_DateTimeUnitType_DateTimeUnitTypeId",
                table: "PastAntiepilepticMedicine",
                column: "DateTimeUnitTypeId",
                principalTable: "DateTimeUnitType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PastAntiepilepticMedicine_DurationOfUseType_DurationOfUseTyp~",
                table: "PastAntiepilepticMedicine",
                column: "DurationOfUseTypeId",
                principalTable: "DurationOfUseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
