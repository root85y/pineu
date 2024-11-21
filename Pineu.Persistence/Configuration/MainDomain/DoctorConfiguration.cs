namespace Pineu.Persistence.Configuration.MainDomain {
    internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor> {
        public void Configure(EntityTypeBuilder<Doctor> builder) {
            builder.ToTable(TableNames.Doctor);

            builder.HasIndex(s => s.Id);
        }
    }
}
