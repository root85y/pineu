namespace Pineu.Persistence.Configuration.MainDomain {
    internal class SleepStatusConfiguration : IEntityTypeConfiguration<SleepStatus> {
        public void Configure(EntityTypeBuilder<SleepStatus> builder) {
            builder.ToTable(TableNames.SleepStatus);
            builder.HasQueryFilter(a => a.DeletedAt == null);

            builder.HasIndex(s => s.UserId);
            builder.HasIndex(ns => ns.Date);
        }
    }
}
