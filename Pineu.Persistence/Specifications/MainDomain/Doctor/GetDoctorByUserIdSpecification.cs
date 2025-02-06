namespace Pineu.Persistence.Specifications.MainDomain.Doctor {
    internal class GetDoctorByUserIdSpecification : Specification<Pineu.Domain.Entities.MainDomain.Doctor> {
        public GetDoctorByUserIdSpecification(Guid userId) {
            Query.Where(m => m.Id == userId);
        }
    }
}
