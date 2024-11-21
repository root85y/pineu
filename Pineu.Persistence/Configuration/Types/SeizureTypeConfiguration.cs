using Pineu.Domain.Entities.Types;

namespace Pineu.Persistence.Configuration.Types;

internal class SeizureTypeConfiguration : IEntityTypeConfiguration<SeizureType> {
    public void Configure(EntityTypeBuilder<SeizureType> builder) {
        builder.ToTable(TableNames.SeizureType);
        builder.HasData(
            new {
                Id = (short)1,
                EnglishName = "Focal",
                FarsiName = "شروع فوکال",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)2,
                EnglishName = "Generalize",
                FarsiName = "شروع ژنرالیزه",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)3,
                EnglishName = "Unknown",
                FarsiName = "شروع ناشناخته",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            }
        );
    }
}