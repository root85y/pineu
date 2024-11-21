namespace Pineu.Persistence.Configuration.MainDomain {
    internal class UserDiscountConfiguration : IEntityTypeConfiguration<UserDiscount> {
        public void Configure(EntityTypeBuilder<UserDiscount> builder) {
            builder.ToTable(TableNames.UserDiscount);
            builder.HasQueryFilter(a => a.DeletedAt == null);
        }
    }
}
