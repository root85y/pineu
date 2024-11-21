using Pineu.Domain.Entities.Types;

namespace Pineu.Persistence.Configuration.Types;

internal class ConsciousnessTypeConfiguration : IEntityTypeConfiguration<ConsciousnessType> {
    public void Configure(EntityTypeBuilder<ConsciousnessType> builder) {
        builder.ToTable(TableNames.ConsciousnessType);
        builder.HasData(
            new {
                Id = (short)1,
                EnglishName = "Conscious",
                FarsiName = "با حفظ آگاهی",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)2,
                EnglishName = "Unconscious",
                FarsiName = "با عدم آگاهی",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            }
        );
    }
}