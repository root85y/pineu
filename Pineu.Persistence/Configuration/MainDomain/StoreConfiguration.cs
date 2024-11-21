namespace Pineu.Persistence.Configuration.MainDomain {
    internal class StoreConfiguration : IEntityTypeConfiguration<Store> {
        public void Configure(EntityTypeBuilder<Store> builder) {
            builder.ToTable(TableNames.Store);
            builder.HasQueryFilter(a => a.DeletedAt == null);
        }
    }
}
