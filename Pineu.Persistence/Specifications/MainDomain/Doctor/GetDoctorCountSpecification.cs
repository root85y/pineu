namespace Pineu.Persistence.Specifications.MainDomain.Doctor {
    internal class GetDoctorCountSpecification : Specification<Pineu.Domain.Entities.MainDomain.Doctor> {
        public GetDoctorCountSpecification() {
            Query.Where(m => m.Mobile != null);
        }
    }
}
