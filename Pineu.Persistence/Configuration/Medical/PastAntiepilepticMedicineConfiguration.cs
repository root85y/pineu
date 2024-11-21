using Pineu.Domain.Entities.Medical;

namespace Pineu.Persistence.Configuration.Medical;

internal class PastAntiepilepticMedicineConfiguration : IEntityTypeConfiguration<PastAntiepilepticMedicine> {
    public void Configure(EntityTypeBuilder<PastAntiepilepticMedicine> builder) {
        builder.ToTable(TableNames.PastAntiepilepticMedicine);
        builder.HasQueryFilter(a => a.DeletedAt == null);
    }
}