namespace Pineu.Persistence.Configuration.MainDomain {
    internal class DiscountConfiguration : IEntityTypeConfiguration<Discount> {
        public void Configure(EntityTypeBuilder<Discount> builder) {
            builder.ToTable(TableNames.Discount);
            builder.HasQueryFilter(a => a.DeletedAt == null);
        }
    }
}
