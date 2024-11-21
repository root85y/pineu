namespace Pineu.Persistence.Configuration.MainDomain {
    internal class ScoreConfiguration : IEntityTypeConfiguration<Score> {
        public void Configure(EntityTypeBuilder<Score> builder) {
            builder.ToTable(TableNames.Score);
            builder.HasQueryFilter(a => a.DeletedAt == null);

            builder.HasData([
                new {
                    Id = Guid.Parse("944A8E74-2343-4416-94C3-E0B8BC6F71D5"),
                    Action = ScoreAction.AddSeizure,
                    ScoreCount = 5,
                    CreatedAt = DateTime.MinValue,
                    UpdatedAt = DateTime.MinValue,
                },
                new {
                    Id = Guid.Parse("FC476934-032A-4EEF-A114-99D69A0F2FEB"),
                    Action = ScoreAction.AddSleepStatus,
                    ScoreCount = 5,
                    CreatedAt = DateTime.MinValue,
                    UpdatedAt = DateTime.MinValue,
                },
                new {
                    Id = Guid.Parse("0A4C629A-A171-4792-86C6-378D1D242E52"),
                    Action = ScoreAction.AddMentalStatus,
                    ScoreCount = 5,
                    CreatedAt = DateTime.MinValue,
                    UpdatedAt = DateTime.MinValue,
                },
                new {
                    Id = Guid.Parse("C2C6EE85-DB55-4625-AE15-3F14A1D68CB5"),
                    Action = ScoreAction.AddWorkoutStatus,
                    ScoreCount = 5,
                    CreatedAt = DateTime.MinValue,
                    UpdatedAt = DateTime.MinValue,
                },
                new {
                    Id = Guid.Parse("AF30E59A-6E08-44BC-85D8-CF3C2FAD132B"),
                    Action = ScoreAction.AddNutritionStatus,
                    ScoreCount = 5,
                    CreatedAt = DateTime.MinValue,
                    UpdatedAt = DateTime.MinValue,
                }]);
        }
    }
}
