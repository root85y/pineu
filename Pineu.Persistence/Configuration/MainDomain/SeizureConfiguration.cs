namespace Pineu.Persistence.Configuration.MainDomain {
    internal class SeizureConfiguration : IEntityTypeConfiguration<Seizure> {
        public void Configure(EntityTypeBuilder<Seizure> builder) {
            builder.ToTable(TableNames.Seizure);
            builder.HasQueryFilter(a => a.DeletedAt == null);

            builder.HasIndex(s => s.SeizureDateTime);
            builder.HasIndex(s => s.UserId);
        }
    }
}
