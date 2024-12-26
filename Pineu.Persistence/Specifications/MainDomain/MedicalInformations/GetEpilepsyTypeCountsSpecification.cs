namespace Pineu.Persistence.Specifications.MainDomain.MedicalInformations {
    internal class GetEpilepsyTypeCountsSpecification : Specification<MedicalInformation> {
        public GetEpilepsyTypeCountsSpecification() {
            Query.Include(mi => mi.EpilepsyTypeId);
        }
    }
}
