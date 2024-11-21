using Pineu.Domain.Entities.Types;

namespace Pineu.Persistence.Configuration.Types;

internal class MovementTypeConfiguration : IEntityTypeConfiguration<MovementType> {
    public void Configure(EntityTypeBuilder<MovementType> builder) {
        builder.ToTable(TableNames.MovementType);
        builder.HasData(
            new {
                Id = (short)1,
                EnglishName = "Movement",
                FarsiName = "حرکتی",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue
            },
            new {
                Id = (short)2,
                EnglishName = "Non moving",
                FarsiName = "غیر حرکتی",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue
            }
        );
    }
}