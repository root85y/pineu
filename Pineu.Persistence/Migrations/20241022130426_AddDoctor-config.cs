using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mobile = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NationalCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonnelCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    CoverId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "4ef34d53-d030-4068-baf2-6613f78ede03", new DateTime(2024, 10, 22, 16, 34, 25, 764, DateTimeKind.Local).AddTicks(8474), "AQAAAAIAAYagAAAAEPWnOiGh501PW1sM9hi/hu4BGTZEj79r0L5W0O1VNK1ugB20BLWkWahug2k0LroH0g==", "d21d9aab-d463-4f77-b31c-c76af4ddb4e9", new DateTime(2024, 10, 22, 16, 34, 25, 764, DateTimeKind.Local).AddTicks(8474) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "61fbc94c-bd21-49e6-94a7-099d7bb3ef39", new DateTime(2024, 10, 22, 16, 34, 25, 845, DateTimeKind.Local).AddTicks(1637), "AQAAAAIAAYagAAAAELHD68grAkNMidbIl5La98ViUqdSNWEbABXINoYm5sG8EI+kH0LYj1+NyqSt1HfS9g==", "726df8c8-780a-4a46-b4d6-36a82606d747", new DateTime(2024, 10, 22, 16, 34, 25, 845, DateTimeKind.Local).AddTicks(1649) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 22, 16, 34, 25, 940, DateTimeKind.Local).AddTicks(5415), new DateTime(2024, 10, 22, 16, 34, 25, 940, DateTimeKind.Local).AddTicks(5422) });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Id",
                table: "Doctor",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctor");

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
    }
}
