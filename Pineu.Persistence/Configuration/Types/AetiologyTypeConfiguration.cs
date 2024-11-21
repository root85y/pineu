using Pineu.Domain.Entities.Types;

namespace Pineu.Persistence.Configuration.Types;

internal class AetiologyTypeConfiguration : IEntityTypeConfiguration<AetiologyType> {
    public void Configure(EntityTypeBuilder<AetiologyType> builder) {
        builder.ToTable(TableNames.AetiologyType);
        builder.HasData(
            new {
                Id = (short)1,
                EnglishName = "Physical",
                FarsiName = "ساختمانی",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)2,
                EnglishName = "Infected",
                FarsiName = "عفونی",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)3,
                EnglishName = "Genetics",
                FarsiName = "ژنتیک",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)4,
                EnglishName = "Immunity",
                FarsiName = "ایمنی",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)5,
                EnglishName = "Metabolic",
                FarsiName = "متابولیک",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            }
        );
    }
}