namespace Pineu.Persistence.Configuration.MainDomain {
    internal class NewsConfiguration : IEntityTypeConfiguration<News> {
        public void Configure(EntityTypeBuilder<News> builder) {
            builder.ToTable(TableNames.News);
            builder.HasQueryFilter(a => a.DeletedAt == null);
        }
    }
}
