using Pineu.Domain.Entities.MainDomain;

namespace Pineu.Persistence.Specifications.MainDomain.Profiles {
    internal class GetProfileByDoctorIdAndstatusSpecification : Specification<Profile> {
        public GetProfileByDoctorIdAndstatusSpecification(Guid DoctorId,string status) {
            Query.Where(m => m.DoctorId == DoctorId && m.Status == status);
        }
    }
}
