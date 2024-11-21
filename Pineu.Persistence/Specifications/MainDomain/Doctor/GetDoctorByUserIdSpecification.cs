namespace Pineu.Persistence.Specifications.MainDomain.Profiles {
    internal class GetDoctorByUserIdSpecification : Specification<Doctor> {
        public GetDoctorByUserIdSpecification(Guid userId) {
            Query.Where(m => m.Id == userId);
        }
    }
}
