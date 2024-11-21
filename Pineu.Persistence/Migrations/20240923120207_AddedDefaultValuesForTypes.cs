using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pineu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultValuesForTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformation_SeizureSymptomsFrequencyType_FrequencyTyp~",
                table: "MedicalInformation");

            migrationBuilder.DropTable(
                name: "SeizureSymptomsFrequencyType");

            migrationBuilder.InsertData(
                table: "AetiologyType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "EnglishName", "FarsiName", "UpdatedAt" },
                values: new object[,]
                {
                    { (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Physical", "ساختمانی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Infected", "عفونی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Genetics", "ژنتیک", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Immunity", "ایمنی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Metabolic", "متابولیک", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

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

            migrationBuilder.InsertData(
                table: "ConsciousnessType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "EnglishName", "FarsiName", "UpdatedAt" },
                values: new object[,]
                {
                    { (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Conscious", "با حفظ آگاهی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Unconscious", "با عدم آگاهی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "DateTimeUnitType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "EnglishName", "FarsiName", "UpdatedAt" },
                values: new object[,]
                {
                    { (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Second", "ثانیه", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Minute", "دقیقه", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hour", "ساعت", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Day", "روز", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Week", "هفته", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Month", "ماه", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Year", "سال", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "DrugType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "EnglishName", "FarsiName", "UpdatedAt" },
                values: new object[,]
                {
                    { (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cigarettes", "سیگار", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hookah", "قلیان", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alcohol", "الکل", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Drugs", "مواد مخدر", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "DurationOfUseType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "EnglishName", "FarsiName", "UpdatedAt" },
                values: new object[,]
                {
                    { (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Less Than Month", "کمتر از یک ماه", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "One to six months", "یک تا شش ماه", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Less than a year", "کمتر از یک سال", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "More than a year", "بیش از یک سال", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EpilepsyType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "EnglishName", "FarsiName", "UpdatedAt" },
                values: new object[,]
                {
                    { (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Focal", "فوکال", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Generalize", "ژنرالیزه", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Combine generalize and focal", "ترکیب فوکال و ژنرالیزه", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Unknown", "ناشناخته", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "FamilyDiseasesHistoryType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "EnglishName", "FarsiName", "UpdatedAt" },
                values: new object[,]
                {
                    { (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Epilepsy", "سابقه صرع", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Neurological problems", "سابقه مشکلات مغز و اعصاب", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Systemic problems", "سابقه مشکلات سیستمیک", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "MovementType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "EnglishName", "FarsiName", "UpdatedAt" },
                values: new object[,]
                {
                    { (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Movement", "حرکتی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Non moving", "غیر حرکتی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OtherDiseaseType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "EnglishName", "FarsiName", "UpdatedAt" },
                values: new object[,]
                {
                    { (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Speech", "اختلالات گفتاری", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Walking", "اختلال راه رفتن", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Psychiatric", "اختلال روانپزشکی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Autism", "اوتیسم", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CP", "فلج مغزی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cognitive disorders and iq", "اختلالات شناختی و آی کیو", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Weakness of limbs", "ضعف اندام ها", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ParentFamilyRelationshipType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "EnglishName", "FarsiName", "UpdatedAt" },
                values: new object[,]
                {
                    { (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Causing", "پسر/دختر عمو/عمه،پسر/دختر دایی/خاله", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Further Relation", "خویشاوند دورتر", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PastYearComplaintType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "EnglishName", "FarsiName", "UpdatedAt" },
                values: new object[,]
                {
                    { (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Repetitive headaches", "سردرد های مکرر", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Syncopation", "سنکوپ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hearing Loss", "کاهش شنوایی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sleep disorder", "اختلال خواب", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bleeding from the nose", "خون ریزی از بینی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Digestive problems", "مشکلات گوارشی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Violent voice", "خشونت صدا", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Shortness of breath", "تنگی نفس", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Swallowing disorder", "اختلال بلع", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Urinary incontinence", "بی اختیاری ادرار", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Weight gain", "افزایش وزن(5کیلو گرم)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Severe constipation", "یبوست شدید", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rectal bleeding", "خونریزی مقعدی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Skin changes and lesions", "تغییرات و ضایعات پوستی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Weight loss", "کاهش وزن(5 کیلو گرم)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SeizureType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "EnglishName", "FarsiName", "UpdatedAt" },
                values: new object[,]
                {
                    { (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Focal", "شروع فوکال", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Generalize", "شروع ژنرالیزه", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { (short)3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Unknown", "شروع ناشناخته", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 23, 15, 32, 6, 579, DateTimeKind.Local).AddTicks(3148), new DateTime(2024, 9, 23, 15, 32, 6, 579, DateTimeKind.Local).AddTicks(3157) });

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformation_DateTimeUnitType_FrequencyTypeId",
                table: "MedicalInformation",
                column: "FrequencyTypeId",
                principalTable: "DateTimeUnitType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformation_DateTimeUnitType_FrequencyTypeId",
                table: "MedicalInformation");

            migrationBuilder.DeleteData(
                table: "AetiologyType",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "AetiologyType",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "AetiologyType",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "AetiologyType",
                keyColumn: "Id",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                table: "AetiologyType",
                keyColumn: "Id",
                keyValue: (short)5);

            migrationBuilder.DeleteData(
                table: "ConsciousnessType",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "ConsciousnessType",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "DateTimeUnitType",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "DateTimeUnitType",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "DateTimeUnitType",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "DateTimeUnitType",
                keyColumn: "Id",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                table: "DateTimeUnitType",
                keyColumn: "Id",
                keyValue: (short)5);

            migrationBuilder.DeleteData(
                table: "DateTimeUnitType",
                keyColumn: "Id",
                keyValue: (short)6);

            migrationBuilder.DeleteData(
                table: "DateTimeUnitType",
                keyColumn: "Id",
                keyValue: (short)7);

            migrationBuilder.DeleteData(
                table: "DrugType",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "DrugType",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "DrugType",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "DrugType",
                keyColumn: "Id",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                table: "DurationOfUseType",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "DurationOfUseType",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "DurationOfUseType",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "DurationOfUseType",
                keyColumn: "Id",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                table: "EpilepsyType",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "EpilepsyType",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "EpilepsyType",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "EpilepsyType",
                keyColumn: "Id",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                table: "FamilyDiseasesHistoryType",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "FamilyDiseasesHistoryType",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "FamilyDiseasesHistoryType",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "MovementType",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "MovementType",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "OtherDiseaseType",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "OtherDiseaseType",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "OtherDiseaseType",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "OtherDiseaseType",
                keyColumn: "Id",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                table: "OtherDiseaseType",
                keyColumn: "Id",
                keyValue: (short)5);

            migrationBuilder.DeleteData(
                table: "OtherDiseaseType",
                keyColumn: "Id",
                keyValue: (short)6);

            migrationBuilder.DeleteData(
                table: "OtherDiseaseType",
                keyColumn: "Id",
                keyValue: (short)7);

            migrationBuilder.DeleteData(
                table: "ParentFamilyRelationshipType",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "ParentFamilyRelationshipType",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "PastYearComplaintType",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "PastYearComplaintType",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "PastYearComplaintType",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "PastYearComplaintType",
                keyColumn: "Id",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                table: "PastYearComplaintType",
                keyColumn: "Id",
                keyValue: (short)5);

            migrationBuilder.DeleteData(
                table: "PastYearComplaintType",
                keyColumn: "Id",
                keyValue: (short)6);

            migrationBuilder.DeleteData(
                table: "PastYearComplaintType",
                keyColumn: "Id",
                keyValue: (short)7);

            migrationBuilder.DeleteData(
                table: "PastYearComplaintType",
                keyColumn: "Id",
                keyValue: (short)8);

            migrationBuilder.DeleteData(
                table: "PastYearComplaintType",
                keyColumn: "Id",
                keyValue: (short)9);

            migrationBuilder.DeleteData(
                table: "PastYearComplaintType",
                keyColumn: "Id",
                keyValue: (short)10);

            migrationBuilder.DeleteData(
                table: "PastYearComplaintType",
                keyColumn: "Id",
                keyValue: (short)11);

            migrationBuilder.DeleteData(
                table: "PastYearComplaintType",
                keyColumn: "Id",
                keyValue: (short)12);

            migrationBuilder.DeleteData(
                table: "PastYearComplaintType",
                keyColumn: "Id",
                keyValue: (short)13);

            migrationBuilder.DeleteData(
                table: "PastYearComplaintType",
                keyColumn: "Id",
                keyValue: (short)14);

            migrationBuilder.DeleteData(
                table: "PastYearComplaintType",
                keyColumn: "Id",
                keyValue: (short)15);

            migrationBuilder.DeleteData(
                table: "SeizureType",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "SeizureType",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "SeizureType",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.CreateTable(
                name: "SeizureSymptomsFrequencyType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EnglishName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FarsiName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeizureSymptomsFrequencyType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "c6041e01-b800-40ff-b240-cbaed48dae4e", new DateTime(2024, 9, 23, 13, 59, 50, 109, DateTimeKind.Local).AddTicks(8087), "AQAAAAIAAYagAAAAEPlepsb71sxmbQpK+r69IIkJsfX0C4EwMNDHnIkY0sd4ZE4lgrL1VVArD7yEwPBw0g==", "dfbfbaeb-5efb-4348-aa07-cf3f8391428e", new DateTime(2024, 9, 23, 13, 59, 50, 109, DateTimeKind.Local).AddTicks(8087) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "ee5e6e5e-bed5-4a1e-9700-dfc20e3a078b", new DateTime(2024, 9, 23, 13, 59, 50, 198, DateTimeKind.Local).AddTicks(195), "AQAAAAIAAYagAAAAEHKZDfpVug/7TT1kpoGnipD4ZgxlP3T8gN3OjVqFy8Bs++Ir0oaPnshXPuBDm8M9AQ==", "bc1e51e8-019d-4b6e-9c85-c251d99c19c7", new DateTime(2024, 9, 23, 13, 59, 50, 198, DateTimeKind.Local).AddTicks(211) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 23, 13, 59, 50, 297, DateTimeKind.Local).AddTicks(7522), new DateTime(2024, 9, 23, 13, 59, 50, 297, DateTimeKind.Local).AddTicks(7533) });

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformation_SeizureSymptomsFrequencyType_FrequencyTyp~",
                table: "MedicalInformation",
                column: "FrequencyTypeId",
                principalTable: "SeizureSymptomsFrequencyType",
                principalColumn: "Id");
        }
    }
}
