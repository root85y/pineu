namespace Pineu.Persistence.Configuration.MainDomain {
    internal class WorkoutStatusConfiguration : IEntityTypeConfiguration<WorkoutStatus> {
        public void Configure(EntityTypeBuilder<WorkoutStatus> builder) {
            builder.ToTable(TableNames.WorkoutStatus);
            builder.HasQueryFilter(a => a.DeletedAt == null);
            
            builder.HasIndex(s => s.UserId);
            builder.HasIndex(ns => ns.Date);
        }
    }
}