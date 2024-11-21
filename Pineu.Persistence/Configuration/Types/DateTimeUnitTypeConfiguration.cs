using Pineu.Domain.Entities.Types;

namespace Pineu.Persistence.Configuration.Types;

internal class DateTimeUnitTypeConfiguration : IEntityTypeConfiguration<DateTimeUnitType> {
    public void Configure(EntityTypeBuilder<DateTimeUnitType> builder) {
        builder.ToTable(TableNames.DateTimeUnitType);
        builder.HasData(
            new {
                Id = (short)1,
                EnglishName = "Second",
                FarsiName = "ثانیه",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)2,
                EnglishName = "Minute",
                FarsiName = "دقیقه",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)3,
                EnglishName = "Hour",
                FarsiName = "ساعت",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)4,
                EnglishName = "Day",
                FarsiName = "روز",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)5,
                EnglishName = "Week",
                FarsiName = "هفته",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)6,
                EnglishName = "Month",
                FarsiName = "ماه",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)7,
                EnglishName = "Year",
                FarsiName = "سال",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            }
        );
    }
}