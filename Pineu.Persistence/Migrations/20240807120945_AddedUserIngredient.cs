using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserIngredient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIngredient", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "7dfdee3e-1458-431e-ab19-642580187bde", new DateTime(2024, 8, 7, 15, 39, 45, 39, DateTimeKind.Local).AddTicks(2345), "AQAAAAIAAYagAAAAEGb8lBPm7VGDfCHqfQYeQaOyyRj0WUE0ejvMM3u8GV1ohsSAwRJXp5KxPlRZy8dKoQ==", "e935200a-6c4e-478a-9a07-c2b68e977478", new DateTime(2024, 8, 7, 15, 39, 45, 39, DateTimeKind.Local).AddTicks(2345) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "414bbb5c-bbbe-41c4-a7ea-553a2f271ef3", new DateTime(2024, 8, 7, 15, 39, 45, 173, DateTimeKind.Local).AddTicks(7395), "AQAAAAIAAYagAAAAEAMHbqLaBvzhhAXeqVgTOLipWJiwJFjv7mLTSR+qhKcbfdYjkXcOXg0ADs3I3zhVmg==", "6fbb861d-c132-4a37-8072-3e82d6684836", new DateTime(2024, 8, 7, 15, 39, 45, 173, DateTimeKind.Local).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 7, 15, 39, 45, 215, DateTimeKind.Local).AddTicks(3146), new DateTime(2024, 8, 7, 15, 39, 45, 215, DateTimeKind.Local).AddTicks(3161) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserIngredient");

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
    }
}
