using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedMedicine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DefaultMedicine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultMedicine", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserMedicine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMedicine", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefaultMedicine");

            migrationBuilder.DropTable(
                name: "UserMedicine");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "686c452a-b3c3-4904-89fc-e209818e37c7", new DateTime(2024, 8, 8, 15, 9, 4, 682, DateTimeKind.Local).AddTicks(2288), "AQAAAAIAAYagAAAAEBBxPTVdRGYJ5ncd8yRdTjw+un1nfzvip/pas8U6TITkjWiZ2Ny3Jqwc73upau3Zjg==", "3dbbf0c2-b727-4a30-842b-0555fa5ac17f", new DateTime(2024, 8, 8, 15, 9, 4, 682, DateTimeKind.Local).AddTicks(2288) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "b45eb4eb-a181-4c5c-909f-ffb334210343", new DateTime(2024, 8, 8, 15, 9, 4, 816, DateTimeKind.Local).AddTicks(6612), "AQAAAAIAAYagAAAAEHH/ghoSagQXSClv+sB14NrC6I+Hx6VSf7ORTK80xZLsb/w3KxbVsgtRThpA9H+LvQ==", "3453f5e1-0299-4d06-baf2-66b2d2179fd3", new DateTime(2024, 8, 8, 15, 9, 4, 816, DateTimeKind.Local).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 8, 15, 9, 4, 848, DateTimeKind.Local).AddTicks(229), new DateTime(2024, 8, 8, 15, 9, 4, 848, DateTimeKind.Local).AddTicks(242) });
        }
    }
}
