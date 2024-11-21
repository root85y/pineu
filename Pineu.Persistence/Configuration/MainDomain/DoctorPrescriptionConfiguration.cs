namespace Pineu.Persistence.Configuration.MainDomain {
    internal class DoctorPrescriptionConfiguration : IEntityTypeConfiguration<DoctorPrescription> {
        public void Configure(EntityTypeBuilder<DoctorPrescription> builder) {
            builder.ToTable(TableNames.DoctorPrescription);
            builder.HasQueryFilter(a => a.DeletedAt == null);

            builder.HasIndex(s => s.UserId);
        }
    }
}
