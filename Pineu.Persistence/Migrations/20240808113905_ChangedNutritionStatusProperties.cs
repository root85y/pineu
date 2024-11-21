using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedNutritionStatusProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Beverages",
                table: "NutritionStatus");

            migrationBuilder.DropColumn(
                name: "Dairy",
                table: "NutritionStatus");

            migrationBuilder.DropColumn(
                name: "Fruits",
                table: "NutritionStatus");

            migrationBuilder.DropColumn(
                name: "Grains",
                table: "NutritionStatus");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "NutritionStatus");

            migrationBuilder.DropColumn(
                name: "SugarAndFat",
                table: "NutritionStatus");

            migrationBuilder.DropColumn(
                name: "Vegetables",
                table: "NutritionStatus");

            migrationBuilder.CreateTable(
                name: "DefaultIngredientNutritionStatus",
                columns: table => new
                {
                    IngredientsId = table.Column<int>(type: "int", nullable: false),
                    NutritionStatusesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultIngredientNutritionStatus", x => new { x.IngredientsId, x.NutritionStatusesId });
                    table.ForeignKey(
                        name: "FK_DefaultIngredientNutritionStatus_DefaultIngredient_Ingredien~",
                        column: x => x.IngredientsId,
                        principalTable: "DefaultIngredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefaultIngredientNutritionStatus_NutritionStatus_NutritionSt~",
                        column: x => x.NutritionStatusesId,
                        principalTable: "NutritionStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NutritionStatusUserIngredient",
                columns: table => new
                {
                    NutritionStatusesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserIngredientsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionStatusUserIngredient", x => new { x.NutritionStatusesId, x.UserIngredientsId });
                    table.ForeignKey(
                        name: "FK_NutritionStatusUserIngredient_NutritionStatus_NutritionStatu~",
                        column: x => x.NutritionStatusesId,
                        principalTable: "NutritionStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NutritionStatusUserIngredient_UserIngredient_UserIngredients~",
                        column: x => x.UserIngredientsId,
                        principalTable: "UserIngredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_DefaultIngredientNutritionStatus_NutritionStatusesId",
                table: "DefaultIngredientNutritionStatus",
                column: "NutritionStatusesId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionStatusUserIngredient_UserIngredientsId",
                table: "NutritionStatusUserIngredient",
                column: "UserIngredientsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefaultIngredientNutritionStatus");

            migrationBuilder.DropTable(
                name: "NutritionStatusUserIngredient");

            migrationBuilder.AddColumn<string>(
                name: "Beverages",
                table: "NutritionStatus",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Dairy",
                table: "NutritionStatus",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Fruits",
                table: "NutritionStatus",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Grains",
                table: "NutritionStatus",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Protein",
                table: "NutritionStatus",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SugarAndFat",
                table: "NutritionStatus",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Vegetables",
                table: "NutritionStatus",
                type: "longtext",
                nullable: false)
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
    }
}
