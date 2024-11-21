using Pineu.Domain.Entities.Medical;

namespace Pineu.Persistence.Configuration.Medical;

internal class FamilyDiseaseHistoryConfiguration : IEntityTypeConfiguration<FamilyDiseaseHistory> {
    public void Configure(EntityTypeBuilder<FamilyDiseaseHistory> builder) {
        builder.ToTable(TableNames.FamilyDiseaseHistory);
        builder.HasQueryFilter(a => a.DeletedAt == null);
    }
}