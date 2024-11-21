using Pineu.Domain.Entities.Types;

namespace Pineu.Persistence.Configuration.Types;

internal class PastYearComplaintTypeConfiguration : IEntityTypeConfiguration<PastYearComplaintType> {
    public void Configure(EntityTypeBuilder<PastYearComplaintType> builder) {
        builder.ToTable(TableNames.PastYearComplaintType);
        builder.HasData(
            new
            {
                Id = (short)1,
                EnglishName = "Repetitive headaches",
                FarsiName = "سردرد های مکرر",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new
            {
                Id = (short)2,
                EnglishName = "Syncopation",
                FarsiName = "سنکوپ",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new
            {
                Id = (short)3,
                EnglishName = "Hearing Loss",
                FarsiName = "کاهش شنوایی",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new
            {
                Id = (short)4,
                EnglishName = "Sleep disorder",
                FarsiName = "اختلال خواب",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new
            {
                Id = (short)5,
                EnglishName = "Bleeding from the nose",
                FarsiName = "خون ریزی از بینی",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new
            {
                Id = (short)6,
                EnglishName = "Digestive problems",
                FarsiName = "مشکلات گوارشی",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new
            {
                Id = (short)7,
                EnglishName = "Violent voice",
                FarsiName = "خشونت صدا",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new
            {
                Id = (short)8,
                EnglishName = "Shortness of breath",
                FarsiName = "تنگی نفس",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new
            {
                Id = (short)9,
                EnglishName = "Swallowing disorder",
                FarsiName = "اختلال بلع",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new
            {
                Id = (short)10,
                EnglishName = "Urinary incontinence",
                FarsiName = "بی اختیاری ادرار",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new
            {
                Id = (short)11,
                EnglishName = "Weight gain",
                FarsiName = "افزایش وزن(5کیلو گرم)",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new
            {
                Id = (short)12,
                EnglishName = "Severe constipation",
                FarsiName = "یبوست شدید",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new
            {
                Id = (short)13,
                EnglishName = "Rectal bleeding",
                FarsiName = "خونریزی مقعدی",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new
            {
                Id = (short)14,
                EnglishName = "Skin changes and lesions",
                FarsiName = "تغییرات و ضایعات پوستی",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new
            {
                Id = (short)15,
                EnglishName = "Weight loss",
                FarsiName = "کاهش وزن(5 کیلو گرم)",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            }
        );
    }
}