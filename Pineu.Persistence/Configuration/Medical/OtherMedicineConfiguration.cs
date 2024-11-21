using Pineu.Domain.Entities.Medical;

namespace Pineu.Persistence.Configuration.Medical; 
internal class OtherMedicineConfiguration : IEntityTypeConfiguration<OtherMedicine> {
    public void Configure(EntityTypeBuilder<OtherMedicine> builder) {
        builder.ToTable(TableNames.OtherMedicine);
        builder.HasQueryFilter(a => a.DeletedAt == null);
    }
}