using Pineu.Domain.Entities.Types;

namespace Pineu.Persistence.Configuration.Types;

internal class FamilyDiseasesHistoryTypeConfiguration : IEntityTypeConfiguration<FamilyDiseasesHistoryType> {
    public void Configure(EntityTypeBuilder<FamilyDiseasesHistoryType> builder) {
        builder.ToTable(TableNames.FamilyDiseasesHistoryType);
        builder.HasData(
            new {
                Id = (short)1,
                EnglishName = "Epilepsy",
                FarsiName = "سابقه صرع",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue
            },
            new {
                Id = (short)2,
                EnglishName = "Neurological problems",
                FarsiName = "سابقه مشکلات مغز و اعصاب",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue
            },
            new {
                Id = (short)3,
                EnglishName = "Systemic problems",
                FarsiName = "سابقه مشکلات سیستمیک",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue
            }
        );
    }
}