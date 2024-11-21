using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pineu.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedTypesAndNewPropsToMedicalInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EpilepsyType",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "FrequencyType",
                table: "MedicalInformation");

            migrationBuilder.AlterColumn<string>(
                name: "SeizureSymptoms",
                table: "MedicalInformation",
                type: "longtext",
                nullable: false,
                defaultValue: "[]",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SeizureInjuryList",
                table: "MedicalInformation",
                type: "longtext",
                nullable: false,
                defaultValue: "[]",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AetiologyDescription",
                table: "MedicalInformation",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateOnly>(
                name: "EegDate",
                table: "MedicalInformation",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EegResult",
                table: "MedicalInformation",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<short>(
                name: "EpilepsyConsciousnessTypeId",
                table: "MedicalInformation",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "EpilepsyMovementTypeId",
                table: "MedicalInformation",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EpilepsySecondType",
                table: "MedicalInformation",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<short>(
                name: "EpilepsyTypeId",
                table: "MedicalInformation",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EpilepticSyndrome",
                table: "MedicalInformation",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FaceFilePath",
                table: "MedicalInformation",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FaceFileUrl",
                table: "MedicalInformation",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FamilyDescription",
                table: "MedicalInformation",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateOnly>(
                name: "FirstSeizure",
                table: "MedicalInformation",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "FrequencyTypeId",
                table: "MedicalInformation",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HospitalizationCount",
                table: "MedicalInformation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "HospitalizationDate",
                table: "MedicalInformation",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HospitalizationDuration",
                table: "MedicalInformation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "HospitalizationTimeUnitId",
                table: "MedicalInformation",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdCardFilePath",
                table: "MedicalInformation",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IdCardFileUrl",
                table: "MedicalInformation",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateOnly>(
                name: "LastSeizure",
                table: "MedicalInformation",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "OtherDiagnosticMeasuresDate",
                table: "MedicalInformation",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherDiagnosticMeasuresResult",
                table: "MedicalInformation",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<short>(
                name: "ParentFamilyRelationshipId",
                table: "MedicalInformation",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "PhotoResult",
                table: "MedicalInformation",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "SeizureConsciousnessTypeId",
                table: "MedicalInformation",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeizureInterval",
                table: "MedicalInformation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "SeizureMovementTypeId",
                table: "MedicalInformation",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeizureSecondType",
                table: "MedicalInformation",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<short>(
                name: "SeizureTimeUnitId",
                table: "MedicalInformation",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "SeizureTypeId",
                table: "MedicalInformation",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SystemicDisease",
                table: "MedicalInformation",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "YearlySeizureCount",
                table: "MedicalInformation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AetiologyType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnglishName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FarsiName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AetiologyType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConsciousnessType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnglishName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FarsiName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsciousnessType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DateTimeUnitType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnglishName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FarsiName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateTimeUnitType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DrugType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnglishName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FarsiName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DurationOfUseType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnglishName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FarsiName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DurationOfUseType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EpilepsyType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnglishName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FarsiName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpilepsyType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FamilyDiseasesHistoryType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnglishName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FarsiName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDiseasesHistoryType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovementType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnglishName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FarsiName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OtherDiseaseType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnglishName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FarsiName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherDiseaseType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ParentFamilyRelationshipType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnglishName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FarsiName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentFamilyRelationshipType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PastYearComplaintType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnglishName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FarsiName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastYearComplaintType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SeizureSymptomsFrequencyType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnglishName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FarsiName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeizureSymptomsFrequencyType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SeizureType",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnglishName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FarsiName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeizureType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AetiologyTypeMedicalInformation",
                columns: table => new
                {
                    AetiologiesId = table.Column<short>(type: "smallint", nullable: false),
                    MedicalInformationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AetiologyTypeMedicalInformation", x => new { x.AetiologiesId, x.MedicalInformationId });
                    table.ForeignKey(
                        name: "FK_AetiologyTypeMedicalInformation_AetiologyType_AetiologiesId",
                        column: x => x.AetiologiesId,
                        principalTable: "AetiologyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AetiologyTypeMedicalInformation_MedicalInformation_MedicalIn~",
                        column: x => x.MedicalInformationId,
                        principalTable: "MedicalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DrugConsumption",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DrugTypeId = table.Column<short>(type: "smallint", nullable: false),
                    DailyAmount = table.Column<int>(type: "int", nullable: false),
                    DrugConsumptionDuration = table.Column<int>(type: "int", nullable: false),
                    DateTimeUnitTypeId = table.Column<short>(type: "smallint", nullable: false),
                    MedicalInformationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugConsumption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugConsumption_DateTimeUnitType_DateTimeUnitTypeId",
                        column: x => x.DateTimeUnitTypeId,
                        principalTable: "DateTimeUnitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugConsumption_DrugType_DrugTypeId",
                        column: x => x.DrugTypeId,
                        principalTable: "DrugType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugConsumption_MedicalInformation_MedicalInformationId",
                        column: x => x.MedicalInformationId,
                        principalTable: "MedicalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CurrentAntiepilepticMedicine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MedicineId = table.Column<int>(type: "int", nullable: true),
                    UserMedicineId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DateTimeUnitTypeId = table.Column<short>(type: "smallint", nullable: false),
                    DurationOfUseTypeId = table.Column<short>(type: "smallint", nullable: false),
                    Complications = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicalInformationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentAntiepilepticMedicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentAntiepilepticMedicine_DateTimeUnitType_DateTimeUnitTy~",
                        column: x => x.DateTimeUnitTypeId,
                        principalTable: "DateTimeUnitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrentAntiepilepticMedicine_DefaultMedicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "DefaultMedicine",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CurrentAntiepilepticMedicine_DurationOfUseType_DurationOfUse~",
                        column: x => x.DurationOfUseTypeId,
                        principalTable: "DurationOfUseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrentAntiepilepticMedicine_MedicalInformation_MedicalInfor~",
                        column: x => x.MedicalInformationId,
                        principalTable: "MedicalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrentAntiepilepticMedicine_UserMedicine_UserMedicineId",
                        column: x => x.UserMedicineId,
                        principalTable: "UserMedicine",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OtherMedicine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MedicineId = table.Column<int>(type: "int", nullable: true),
                    UserMedicineId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DateTimeUnitTypeId = table.Column<short>(type: "smallint", nullable: false),
                    DurationOfUseTypeId = table.Column<short>(type: "smallint", nullable: false),
                    Complications = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicalInformationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherMedicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherMedicine_DateTimeUnitType_DateTimeUnitTypeId",
                        column: x => x.DateTimeUnitTypeId,
                        principalTable: "DateTimeUnitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherMedicine_DefaultMedicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "DefaultMedicine",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OtherMedicine_DurationOfUseType_DurationOfUseTypeId",
                        column: x => x.DurationOfUseTypeId,
                        principalTable: "DurationOfUseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherMedicine_MedicalInformation_MedicalInformationId",
                        column: x => x.MedicalInformationId,
                        principalTable: "MedicalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherMedicine_UserMedicine_UserMedicineId",
                        column: x => x.UserMedicineId,
                        principalTable: "UserMedicine",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PastAntiepilepticMedicine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MedicineId = table.Column<int>(type: "int", nullable: true),
                    UserMedicineId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DateTimeUnitTypeId = table.Column<short>(type: "smallint", nullable: false),
                    DurationOfUseTypeId = table.Column<short>(type: "smallint", nullable: false),
                    StopDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ReasonOfStop = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicalInformationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastAntiepilepticMedicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PastAntiepilepticMedicine_DateTimeUnitType_DateTimeUnitTypeId",
                        column: x => x.DateTimeUnitTypeId,
                        principalTable: "DateTimeUnitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PastAntiepilepticMedicine_DefaultMedicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "DefaultMedicine",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PastAntiepilepticMedicine_DurationOfUseType_DurationOfUseTyp~",
                        column: x => x.DurationOfUseTypeId,
                        principalTable: "DurationOfUseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PastAntiepilepticMedicine_MedicalInformation_MedicalInformat~",
                        column: x => x.MedicalInformationId,
                        principalTable: "MedicalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PastAntiepilepticMedicine_UserMedicine_UserMedicineId",
                        column: x => x.UserMedicineId,
                        principalTable: "UserMedicine",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FamilyDiseaseHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FamilyDiseasesHistoryTypeId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Relationship = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicalInformationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDiseaseHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyDiseaseHistory_FamilyDiseasesHistoryType_FamilyDisease~",
                        column: x => x.FamilyDiseasesHistoryTypeId,
                        principalTable: "FamilyDiseasesHistoryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyDiseaseHistory_MedicalInformation_MedicalInformationId",
                        column: x => x.MedicalInformationId,
                        principalTable: "MedicalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicalInformationOtherDiseaseType",
                columns: table => new
                {
                    MedicalInformationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OtherDiseaseId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalInformationOtherDiseaseType", x => new { x.MedicalInformationId, x.OtherDiseaseId });
                    table.ForeignKey(
                        name: "FK_MedicalInformationOtherDiseaseType_MedicalInformation_Medica~",
                        column: x => x.MedicalInformationId,
                        principalTable: "MedicalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalInformationOtherDiseaseType_OtherDiseaseType_OtherDis~",
                        column: x => x.OtherDiseaseId,
                        principalTable: "OtherDiseaseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicalInformationPastYearComplaintType",
                columns: table => new
                {
                    MedicalInformationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PastYearComplaintsId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalInformationPastYearComplaintType", x => new { x.MedicalInformationId, x.PastYearComplaintsId });
                    table.ForeignKey(
                        name: "FK_MedicalInformationPastYearComplaintType_MedicalInformation_M~",
                        column: x => x.MedicalInformationId,
                        principalTable: "MedicalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalInformationPastYearComplaintType_PastYearComplaintTyp~",
                        column: x => x.PastYearComplaintsId,
                        principalTable: "PastYearComplaintType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformation_EpilepsyConsciousnessTypeId",
                table: "MedicalInformation",
                column: "EpilepsyConsciousnessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformation_EpilepsyMovementTypeId",
                table: "MedicalInformation",
                column: "EpilepsyMovementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformation_EpilepsyTypeId",
                table: "MedicalInformation",
                column: "EpilepsyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformation_FrequencyTypeId",
                table: "MedicalInformation",
                column: "FrequencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformation_HospitalizationTimeUnitId",
                table: "MedicalInformation",
                column: "HospitalizationTimeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformation_ParentFamilyRelationshipId",
                table: "MedicalInformation",
                column: "ParentFamilyRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformation_SeizureConsciousnessTypeId",
                table: "MedicalInformation",
                column: "SeizureConsciousnessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformation_SeizureMovementTypeId",
                table: "MedicalInformation",
                column: "SeizureMovementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformation_SeizureTimeUnitId",
                table: "MedicalInformation",
                column: "SeizureTimeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformation_SeizureTypeId",
                table: "MedicalInformation",
                column: "SeizureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AetiologyTypeMedicalInformation_MedicalInformationId",
                table: "AetiologyTypeMedicalInformation",
                column: "MedicalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAntiepilepticMedicine_DateTimeUnitTypeId",
                table: "CurrentAntiepilepticMedicine",
                column: "DateTimeUnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAntiepilepticMedicine_DurationOfUseTypeId",
                table: "CurrentAntiepilepticMedicine",
                column: "DurationOfUseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAntiepilepticMedicine_MedicalInformationId",
                table: "CurrentAntiepilepticMedicine",
                column: "MedicalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAntiepilepticMedicine_MedicineId",
                table: "CurrentAntiepilepticMedicine",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAntiepilepticMedicine_UserMedicineId",
                table: "CurrentAntiepilepticMedicine",
                column: "UserMedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugConsumption_DateTimeUnitTypeId",
                table: "DrugConsumption",
                column: "DateTimeUnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugConsumption_DrugTypeId",
                table: "DrugConsumption",
                column: "DrugTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugConsumption_MedicalInformationId",
                table: "DrugConsumption",
                column: "MedicalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDiseaseHistory_FamilyDiseasesHistoryTypeId",
                table: "FamilyDiseaseHistory",
                column: "FamilyDiseasesHistoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDiseaseHistory_MedicalInformationId",
                table: "FamilyDiseaseHistory",
                column: "MedicalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformationOtherDiseaseType_OtherDiseaseId",
                table: "MedicalInformationOtherDiseaseType",
                column: "OtherDiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInformationPastYearComplaintType_PastYearComplaintsId",
                table: "MedicalInformationPastYearComplaintType",
                column: "PastYearComplaintsId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherMedicine_DateTimeUnitTypeId",
                table: "OtherMedicine",
                column: "DateTimeUnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherMedicine_DurationOfUseTypeId",
                table: "OtherMedicine",
                column: "DurationOfUseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherMedicine_MedicalInformationId",
                table: "OtherMedicine",
                column: "MedicalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherMedicine_MedicineId",
                table: "OtherMedicine",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherMedicine_UserMedicineId",
                table: "OtherMedicine",
                column: "UserMedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PastAntiepilepticMedicine_DateTimeUnitTypeId",
                table: "PastAntiepilepticMedicine",
                column: "DateTimeUnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PastAntiepilepticMedicine_DurationOfUseTypeId",
                table: "PastAntiepilepticMedicine",
                column: "DurationOfUseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PastAntiepilepticMedicine_MedicalInformationId",
                table: "PastAntiepilepticMedicine",
                column: "MedicalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PastAntiepilepticMedicine_MedicineId",
                table: "PastAntiepilepticMedicine",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PastAntiepilepticMedicine_UserMedicineId",
                table: "PastAntiepilepticMedicine",
                column: "UserMedicineId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformation_ConsciousnessType_EpilepsyConsciousnessTy~",
                table: "MedicalInformation",
                column: "EpilepsyConsciousnessTypeId",
                principalTable: "ConsciousnessType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformation_ConsciousnessType_SeizureConsciousnessTyp~",
                table: "MedicalInformation",
                column: "SeizureConsciousnessTypeId",
                principalTable: "ConsciousnessType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformation_DateTimeUnitType_HospitalizationTimeUnitId",
                table: "MedicalInformation",
                column: "HospitalizationTimeUnitId",
                principalTable: "DateTimeUnitType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformation_DateTimeUnitType_SeizureTimeUnitId",
                table: "MedicalInformation",
                column: "SeizureTimeUnitId",
                principalTable: "DateTimeUnitType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformation_EpilepsyType_EpilepsyTypeId",
                table: "MedicalInformation",
                column: "EpilepsyTypeId",
                principalTable: "EpilepsyType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformation_MovementType_EpilepsyMovementTypeId",
                table: "MedicalInformation",
                column: "EpilepsyMovementTypeId",
                principalTable: "MovementType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformation_MovementType_SeizureMovementTypeId",
                table: "MedicalInformation",
                column: "SeizureMovementTypeId",
                principalTable: "MovementType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformation_ParentFamilyRelationshipType_ParentFamily~",
                table: "MedicalInformation",
                column: "ParentFamilyRelationshipId",
                principalTable: "ParentFamilyRelationshipType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformation_SeizureSymptomsFrequencyType_FrequencyTyp~",
                table: "MedicalInformation",
                column: "FrequencyTypeId",
                principalTable: "SeizureSymptomsFrequencyType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalInformation_SeizureType_SeizureTypeId",
                table: "MedicalInformation",
                column: "SeizureTypeId",
                principalTable: "SeizureType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformation_ConsciousnessType_EpilepsyConsciousnessTy~",
                table: "MedicalInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformation_ConsciousnessType_SeizureConsciousnessTyp~",
                table: "MedicalInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformation_DateTimeUnitType_HospitalizationTimeUnitId",
                table: "MedicalInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformation_DateTimeUnitType_SeizureTimeUnitId",
                table: "MedicalInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformation_EpilepsyType_EpilepsyTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformation_MovementType_EpilepsyMovementTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformation_MovementType_SeizureMovementTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformation_ParentFamilyRelationshipType_ParentFamily~",
                table: "MedicalInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformation_SeizureSymptomsFrequencyType_FrequencyTyp~",
                table: "MedicalInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalInformation_SeizureType_SeizureTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropTable(
                name: "AetiologyTypeMedicalInformation");

            migrationBuilder.DropTable(
                name: "ConsciousnessType");

            migrationBuilder.DropTable(
                name: "CurrentAntiepilepticMedicine");

            migrationBuilder.DropTable(
                name: "DrugConsumption");

            migrationBuilder.DropTable(
                name: "EpilepsyType");

            migrationBuilder.DropTable(
                name: "FamilyDiseaseHistory");

            migrationBuilder.DropTable(
                name: "MedicalInformationOtherDiseaseType");

            migrationBuilder.DropTable(
                name: "MedicalInformationPastYearComplaintType");

            migrationBuilder.DropTable(
                name: "MovementType");

            migrationBuilder.DropTable(
                name: "OtherMedicine");

            migrationBuilder.DropTable(
                name: "ParentFamilyRelationshipType");

            migrationBuilder.DropTable(
                name: "PastAntiepilepticMedicine");

            migrationBuilder.DropTable(
                name: "SeizureSymptomsFrequencyType");

            migrationBuilder.DropTable(
                name: "SeizureType");

            migrationBuilder.DropTable(
                name: "AetiologyType");

            migrationBuilder.DropTable(
                name: "DrugType");

            migrationBuilder.DropTable(
                name: "FamilyDiseasesHistoryType");

            migrationBuilder.DropTable(
                name: "OtherDiseaseType");

            migrationBuilder.DropTable(
                name: "PastYearComplaintType");

            migrationBuilder.DropTable(
                name: "DateTimeUnitType");

            migrationBuilder.DropTable(
                name: "DurationOfUseType");

            migrationBuilder.DropIndex(
                name: "IX_MedicalInformation_EpilepsyConsciousnessTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropIndex(
                name: "IX_MedicalInformation_EpilepsyMovementTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropIndex(
                name: "IX_MedicalInformation_EpilepsyTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropIndex(
                name: "IX_MedicalInformation_FrequencyTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropIndex(
                name: "IX_MedicalInformation_HospitalizationTimeUnitId",
                table: "MedicalInformation");

            migrationBuilder.DropIndex(
                name: "IX_MedicalInformation_ParentFamilyRelationshipId",
                table: "MedicalInformation");

            migrationBuilder.DropIndex(
                name: "IX_MedicalInformation_SeizureConsciousnessTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropIndex(
                name: "IX_MedicalInformation_SeizureMovementTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropIndex(
                name: "IX_MedicalInformation_SeizureTimeUnitId",
                table: "MedicalInformation");

            migrationBuilder.DropIndex(
                name: "IX_MedicalInformation_SeizureTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "AetiologyDescription",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "EegDate",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "EegResult",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "EpilepsyConsciousnessTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "EpilepsyMovementTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "EpilepsySecondType",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "EpilepsyTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "EpilepticSyndrome",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "FaceFilePath",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "FaceFileUrl",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "FamilyDescription",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "FirstSeizure",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "FrequencyTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "HospitalizationCount",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "HospitalizationDate",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "HospitalizationDuration",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "HospitalizationTimeUnitId",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "IdCardFilePath",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "IdCardFileUrl",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "LastSeizure",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "OtherDiagnosticMeasuresDate",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "OtherDiagnosticMeasuresResult",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "ParentFamilyRelationshipId",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "PhotoResult",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "SeizureConsciousnessTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "SeizureInterval",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "SeizureMovementTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "SeizureSecondType",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "SeizureTimeUnitId",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "SeizureTypeId",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "SystemicDisease",
                table: "MedicalInformation");

            migrationBuilder.DropColumn(
                name: "YearlySeizureCount",
                table: "MedicalInformation");

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

            migrationBuilder.AddColumn<byte>(
                name: "EpilepsyType",
                table: "MedicalInformation",
                type: "tinyint unsigned",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "FrequencyType",
                table: "MedicalInformation",
                type: "tinyint unsigned",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a1450d11-4a4e-402a-a94e-59d29bba6f81"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "f294b946-2329-4b72-b4a7-c0d614cb33cd", new DateTime(2024, 8, 31, 10, 45, 6, 281, DateTimeKind.Local).AddTicks(5219), "AQAAAAIAAYagAAAAEC9DRudcxxNeS4M19vLWwPybmafEhjKNS1oSd8JuzgYu2bpAmIazEZk//JgKkPPW5A==", "592ffae8-0f0e-4c12-9874-bc0903b183c1", new DateTime(2024, 8, 31, 10, 45, 6, 281, DateTimeKind.Local).AddTicks(5219) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd98f5ef-1c0a-4c71-94c6-fcefa42fa0c0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "d1181fa3-eaa8-4444-9fea-7ddc17fcbcdf", new DateTime(2024, 8, 31, 10, 45, 6, 368, DateTimeKind.Local).AddTicks(4348), "AQAAAAIAAYagAAAAENVuoNVkQwCW36ZIn9gPKaJ6Gi0TkwqlugsZsVcvZk7u0YKXaoKg297VLV55iKxH/g==", "d824926b-bba3-4826-a32d-fd85247d6d62", new DateTime(2024, 8, 31, 10, 45, 6, 368, DateTimeKind.Local).AddTicks(4361) });

            migrationBuilder.UpdateData(
                table: "SystemFile",
                keyColumn: "Id",
                keyValue: new Guid("d6814787-0f1e-4389-b48e-dff0f2b36ca7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 31, 10, 45, 6, 388, DateTimeKind.Local).AddTicks(2175), new DateTime(2024, 8, 31, 10, 45, 6, 388, DateTimeKind.Local).AddTicks(2184) });
        }
    }
}
