namespace Pineu.Persistence.Configuration.MainDomain {
    internal class BannerConfiguration : IEntityTypeConfiguration<Banner> {
        public void Configure(EntityTypeBuilder<Banner> builder) {
            builder.ToTable(TableNames.Banner);
            builder.HasQueryFilter(a => a.DeletedAt == null);
        }
    }
}
