namespace Pineu.Persistence.Configuration.MainDomain {
    internal class ProfileConfiguration : IEntityTypeConfiguration<Profile> {
        public void Configure(EntityTypeBuilder<Profile> builder) {
            builder.ToTable(TableNames.Profile);
            builder.HasQueryFilter(a => a.DeletedAt == null);
        }
    }
}
