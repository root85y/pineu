using Pineu.Domain.Entities.Types;

namespace Pineu.Persistence.Configuration.Types;

internal class OtherDiseaseTypeConfiguration : IEntityTypeConfiguration<OtherDiseaseType> {
    public void Configure(EntityTypeBuilder<OtherDiseaseType> builder) {
        builder.ToTable(TableNames.OtherDiseaseType);
        builder.HasData(
            new {
                Id = (short)1,
                EnglishName = "Speech",
                FarsiName = "اختلالات گفتاری",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)2,
                EnglishName = "Walking",
                FarsiName = "اختلال راه رفتن",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)3,
                EnglishName = "Psychiatric",
                FarsiName = "اختلال روانپزشکی",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)4,
                EnglishName = "Autism",
                FarsiName = "اوتیسم",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)5,
                EnglishName = "CP",
                FarsiName = "فلج مغزی",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)6,
                EnglishName = "Cognitive disorders and iq",
                FarsiName = "اختلالات شناختی و آی کیو",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)7,
                EnglishName = "Weakness of limbs",
                FarsiName = "ضعف اندام ها",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            }
        );
    }
}