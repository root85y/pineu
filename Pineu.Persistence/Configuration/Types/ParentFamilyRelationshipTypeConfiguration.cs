using Pineu.Domain.Entities.Types;

namespace Pineu.Persistence.Configuration.Types;

internal class ParentFamilyRelationshipTypeConfiguration : IEntityTypeConfiguration<ParentFamilyRelationshipType> {
    public void Configure(EntityTypeBuilder<ParentFamilyRelationshipType> builder) {
        builder.ToTable(TableNames.ParentFamilyRelationshipType);
        builder.HasData(
            new {
                Id = (short)1,
                EnglishName = "Causing",
                FarsiName = "پسر/دختر عمو/عمه،پسر/دختر دایی/خاله",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            },
            new {
                Id = (short)2,
                EnglishName = "Further Relation",
                FarsiName = "خویشاوند دورتر",
                CreatedAt = DateTime.MinValue,
                UpdatedAt = DateTime.MinValue,
            }
        );
    }
}