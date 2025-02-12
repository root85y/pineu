using System.Threading;

namespace Pineu.Persistence.Specifications.MainDomain.MedicalInformations {
    internal class GetMedicalInformationByIdSpecification : Specification<MedicalInformation> {
        public GetMedicalInformationByIdSpecification(Guid userId) {
            Query.Where(m => m.UserId == userId);
            Query.Include(m => m.EpilepsyType)
            .Include(m => m.SeizureType)
            .Include(m => m.SeizureConsciousnessType)
            .Include(m => m.SeizureMovementType)
            .Include(m => m.SeizureTimeUnit)
            .Include(m => m.ParentFamilyRelationship)
            .Include(m => m.Aetiologies)
            .Include(m => m.OtherDisease)
            .Include(m => m.PastAntiepilepticMedicines)
                .ThenInclude(p => p.Medicine)
            .Include(m => m.PastAntiepilepticMedicines)
                .ThenInclude(p => p.UserMedicine)
            .Include(m => m.CurrentAntiepilepticMedicines)
                .ThenInclude(c => c.Medicine)
            .Include(m => m.CurrentAntiepilepticMedicines)
                .ThenInclude(c => c.UserMedicine)
            .Include(m => m.OtherMedicines)
                .ThenInclude(o => o.Medicine)
            .Include(m => m.OtherMedicines)
                .ThenInclude(o => o.UserMedicine)
            .Include(m => m.FamilyDiseaseHistory)
            .Include(m => m.DrugConsumption)
            .AsSplitQuery();
        }
    }
}
