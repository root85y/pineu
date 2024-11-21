namespace Pineu.Persistence.Configuration.MainDomain {
    internal class NutritionStatusConfiguration : IEntityTypeConfiguration<NutritionStatus> {
        public void Configure(EntityTypeBuilder<NutritionStatus> builder) {
            builder.ToTable(TableNames.NutritionStatus);
            builder.HasQueryFilter(a => a.DeletedAt == null);

            builder.HasMany(ns => ns.Ingredients).WithMany(i => i.NutritionStatuses);
            builder.HasMany(ns => ns.UserIngredients).WithMany(i => i.NutritionStatuses);

            builder.HasIndex(s => s.UserId);
            builder.HasIndex(ns => ns.Date);
        }
    }
}
