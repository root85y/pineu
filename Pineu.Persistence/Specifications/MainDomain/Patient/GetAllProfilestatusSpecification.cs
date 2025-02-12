using Pineu.Domain.Entities.MainDomain;

namespace Pineu.Persistence.Specifications.MainDomain.Profiles {
    internal class GetAllProfilestatusSpecification : Specification<Profile> {
        public GetAllProfilestatusSpecification(string status) {
            Query.Where(m => m.Status == status);
        }
    }
}
