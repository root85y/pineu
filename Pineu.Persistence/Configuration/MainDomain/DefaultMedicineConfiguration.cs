namespace Pineu.Persistence.Configuration.MainDomain;

internal class DefaultMedicineConfiguration : IEntityTypeConfiguration<DefaultMedicine>
{
    public void Configure(EntityTypeBuilder<DefaultMedicine> builder)
    {
        builder.ToTable(TableNames.DefaultMedicine);
        builder.HasQueryFilter(a => a.DeletedAt == null);
    }
}