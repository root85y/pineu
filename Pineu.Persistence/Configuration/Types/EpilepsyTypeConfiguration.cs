using Pineu.Domain.Entities.Types;

namespace Pineu.Persistence.Configuration.Types;
internal class EpilepsyTypeConfiguration : IEntityTypeConfiguration<EpilepsyType> {
    public void Configure(EntityTypeBuilder<EpilepsyType> builder) {
        builder.ToTable(TableNames.EpilepsyType);
        builder.HasData(
            new {
                Id = (short)1,
                EnglishName = "Focal",
                FarsiName = "فوکال",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue
            },
            new {
                Id = (short)2,
                EnglishName = "Generalize",
                FarsiName = "ژنرالیزه",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue
            },
            new {
                Id = (short)3,
                EnglishName = "Combine generalize and focal",
                FarsiName = "ترکیب فوکال و ژنرالیزه",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue
            },
            new {
                Id = (short)4,
                EnglishName = "Unknown",
                FarsiName = "ناشناخته",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue
            }
        );
    }
}