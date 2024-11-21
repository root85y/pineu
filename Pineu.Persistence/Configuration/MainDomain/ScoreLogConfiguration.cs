namespace Pineu.Persistence.Configuration.MainDomain {
    internal class ScoreLogConfiguration : IEntityTypeConfiguration<ScoreLog> {
        public void Configure(EntityTypeBuilder<ScoreLog> builder) {
            builder.ToTable(TableNames.ScoreLog);
            builder.HasQueryFilter(a => a.DeletedAt == null);
        }
    }
}
