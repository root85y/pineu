namespace Pineu.Persistence.Configuration.MainDomain {
    internal class MedicalInformationConfiguration : IEntityTypeConfiguration<MedicalInformation> {
        public void Configure(EntityTypeBuilder<MedicalInformation> builder) {
            builder.ToTable(TableNames.MedicalInformation);
            builder.HasQueryFilter(a => a.DeletedAt == null);
            builder.HasIndex(s => s.UserId);

            builder.HasOne(mi => mi.EpilepsyConsciousnessType).WithMany();
            builder.HasOne(mi => mi.EpilepsyMovementType).WithMany();
            builder.HasOne(mi => mi.SeizureType).WithMany();
            builder.HasOne(mi => mi.SeizureConsciousnessType).WithMany();
            builder.HasOne(mi => mi.SeizureMovementType).WithMany();
            builder.HasMany(mi => mi.Aetiologies).WithMany();
            builder.HasMany(mi => mi.OtherDisease).WithMany();
            builder.HasMany(mi => mi.PastAntiepilepticMedicines).WithOne(pam => pam.MedicalInformation).
                OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(mi => mi.CurrentAntiepilepticMedicines).WithOne(cap => cap.MedicalInformation).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(mi => mi.OtherMedicines).WithOne(cap => cap.MedicalInformation).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(mi => mi.SeizureTimeUnit).WithMany();
            builder.HasOne(mi => mi.ParentFamilyRelationship).WithMany();
            builder.HasOne(mi => mi.HospitalizationTimeUnit).WithMany();
            builder.HasMany(mi => mi.PastYearComplaints).WithMany();
            builder.HasMany(mi => mi.FamilyDiseaseHistory).WithOne(cap => cap.MedicalInformation).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(mi => mi.DrugConsumption).WithOne(cap => cap.MedicalInformation).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
