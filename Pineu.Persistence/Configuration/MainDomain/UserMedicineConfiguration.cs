namespace Pineu.Persistence.Configuration.MainDomain;

internal class UserMedicineConfiguration : IEntityTypeConfiguration<UserMedicine>
{
    public void Configure(EntityTypeBuilder<UserMedicine> builder)
    {
        builder.ToTable(TableNames.UserMedicine);
        builder.HasQueryFilter(a => a.DeletedAt == null);

        builder.HasIndex(s => s.UserId);
    }
}