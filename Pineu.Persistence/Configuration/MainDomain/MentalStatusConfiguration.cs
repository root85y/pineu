namespace Pineu.Persistence.Configuration.MainDomain {
    internal class MentalStatusConfiguration : IEntityTypeConfiguration<MentalStatus> {
        public void Configure(EntityTypeBuilder<MentalStatus> builder) {
            builder.ToTable(TableNames.MentalStatus);
            builder.HasQueryFilter(a => a.DeletedAt == null);

            builder.HasIndex(ns => ns.Date);
            builder.HasIndex(s => s.UserId);
        }
    }
}
