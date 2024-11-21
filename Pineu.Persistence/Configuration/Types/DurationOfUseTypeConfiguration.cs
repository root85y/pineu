using Pineu.Domain.Entities.Types;

namespace Pineu.Persistence.Configuration.Types;

internal class DurationOfUseTypeConfiguration : IEntityTypeConfiguration<DurationOfUseType> {
    public void Configure(EntityTypeBuilder<DurationOfUseType> builder) {
        builder.ToTable(TableNames.DurationOfUseType);
        builder.HasData(
            new {
                Id = (short)1,
                EnglishName = "Less Than Month",
                FarsiName = "کمتر از یک ماه",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue
            },
            new {
                Id = (short)2,
                EnglishName = "One to six months",
                FarsiName = "یک تا شش ماه",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue
            },
            new {
                Id = (short)3,
                EnglishName = "Less than a year",
                FarsiName = "کمتر از یک سال",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue
            },
            new {
                Id = (short)4,
                EnglishName = "More than a year",
                FarsiName = "بیش از یک سال",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue
            }
        );
    }
}