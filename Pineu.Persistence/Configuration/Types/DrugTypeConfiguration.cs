using Pineu.Domain.Entities.Types;

namespace Pineu.Persistence.Configuration.Types;

internal class DrugTypeConfiguration : IEntityTypeConfiguration<DrugType> {
    public void Configure(EntityTypeBuilder<DrugType> builder) {
        builder.ToTable(TableNames.DrugType);
        builder.HasData(
            new {
                Id = (short)1,
                EnglishName = "Cigarettes",
                FarsiName = "سیگار",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)2,
                EnglishName = "Hookah",
                FarsiName = "قلیان",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)3,
                EnglishName = "Alcohol",
                FarsiName = "الکل",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)4,
                EnglishName = "Drugs",
                FarsiName = "مواد مخدر",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            }
        );
    }
}