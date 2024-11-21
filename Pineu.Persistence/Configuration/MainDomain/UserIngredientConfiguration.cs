namespace Pineu.Persistence.Configuration.MainDomain {
    internal class UserIngredientConfiguration : IEntityTypeConfiguration<UserIngredient> {
        public void Configure(EntityTypeBuilder<UserIngredient> builder) {
            builder.ToTable(TableNames.UserIngredient);
            builder.HasIndex(s => s.UserId);
        }
    }
}
