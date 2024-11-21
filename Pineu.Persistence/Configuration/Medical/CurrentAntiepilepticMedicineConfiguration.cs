using Pineu.Domain.Entities.Medical;

namespace Pineu.Persistence.Configuration.Medical;

internal class CurrentAntiepilepticMedicineConfiguration : IEntityTypeConfiguration<CurrentAntiepilepticMedicine> {
    public void Configure(EntityTypeBuilder<CurrentAntiepilepticMedicine> builder) {
        builder.ToTable(TableNames.CurrentAntiepilepticMedicine);
        builder.HasQueryFilter(a => a.DeletedAt == null);
    }
}