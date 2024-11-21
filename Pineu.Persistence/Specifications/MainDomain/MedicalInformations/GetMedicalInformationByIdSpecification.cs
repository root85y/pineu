namespace Pineu.Persistence.Specifications.MainDomain.MedicalInformations {
    internal class GetMedicalInformationByIdSpecification : Specification<MedicalInformation> {
        public GetMedicalInformationByIdSpecification(Guid userId) {
            Query.Where(m => m.UserId == userId);
            Query.Include(mi => mi.Aetiologies)
                .Include(mi => mi.OtherDisease)
                .Include(mi => mi.PastAntiepilepticMedicines)
                .ThenInclude(pam => pam.Medicine)
                .Include(mi => mi.PastAntiepilepticMedicines)
                .ThenInclude(pam => pam.UserMedicine)
                .Include(mi => mi.CurrentAntiepilepticMedicines)
                .ThenInclude(mi => mi.UserMedicine)
                .Include(mi => mi.CurrentAntiepilepticMedicines)
                .ThenInclude(mi => mi.Medicine)
                .Include(mi => mi.OtherMedicines)
                .ThenInclude(mi => mi.Medicine)
                .Include(mi => mi.OtherMedicines)
                .ThenInclude(mi => mi.UserMedicine)
                .Include(mi => mi.PastYearComplaints)
                .Include(mi => mi.FamilyDiseaseHistory)
                .Include(mi => mi.DrugConsumption)
                .AsSplitQuery();
        }
    }
}
