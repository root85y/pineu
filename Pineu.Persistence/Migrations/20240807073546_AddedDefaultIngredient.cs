using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DefaultIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnglishLabel = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FarsiLabel = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultIngredient", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "b8a19ef1-4aa8-474d-8a64-ab4a5647ca03", new DateTime(2024, 8, 7, 11, 5, 45, 410, DateTimeKind.Local).AddTicks(7297), "AQAAAAIAAYagAAAAEEunZkdZTnRYE+PSjc+lFg8K/D9FV4uEtgNH5iuwe2Lr9Y+5kI3e478Kugtaw3R4hg==", "b6cd1e1c-52e8-4d7a-9ca2-08c20bfa2442", new DateTime(2024, 8, 7, 11, 5, 45, 410, DateTimeKind.Local).AddTicks(7298) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "24e0ab30-e50a-44c2-852e-6942ccaa7b45", new DateTime(2024, 8, 7, 11, 5, 45, 545, DateTimeKind.Local).AddTicks(7075), "AQAAAAIAAYagAAAAEGaLMSVD6cHplvp9pgWIVT9uP81eX7MYaiAt+A5aq3A5fGcbid8cP3LNRpoqVGmWqA==", "b0bdbc2a-b621-478d-a9ee-463d8c0c77d3", new DateTime(2024, 8, 7, 11, 5, 45, 545, DateTimeKind.Local).AddTicks(7090) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 7, 11, 5, 45, 572, DateTimeKind.Local).AddTicks(8553), new DateTime(2024, 8, 7, 11, 5, 45, 572, DateTimeKind.Local).AddTicks(8564) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefaultIngredient");

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
    }
}
