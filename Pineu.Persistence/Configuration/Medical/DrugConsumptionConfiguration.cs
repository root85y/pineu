using Pineu.Domain.Entities.Medical;

namespace Pineu.Persistence.Configuration.Medical; 
internal class DrugConsumptionConfiguration : IEntityTypeConfiguration<DrugConsumption> {
    public void Configure(EntityTypeBuilder<DrugConsumption> builder) {
        builder.ToTable(TableNames.DrugConsumption);
        builder.HasQueryFilter(a => a.DeletedAt == null);
    }
}
