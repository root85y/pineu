using Pineu.Domain.Entities.MainDomain;

namespace Pineu.Persistence.Specifications.MainDomain.Profiles {
    internal class GetFullProfileWithPatientIDSpecification : Specification<Profile> {
        public GetFullProfileWithPatientIDSpecification(Guid PatientID,Guid doctorId) {
            Query.Where(m => m.UserId == PatientID);
            Query.Where(m => m.DoctorId == doctorId);
        }
    }
}
