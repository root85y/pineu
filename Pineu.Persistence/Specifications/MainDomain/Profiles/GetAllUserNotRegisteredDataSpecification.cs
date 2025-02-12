namespace Pineu.Persistence.Specifications.MainDomain.Profiles {
    internal class GetAllUserNotRegisteredDataSpecification : Specification<Profile> {
        public GetAllUserNotRegisteredDataSpecification(string status) {
            Query.Where(m => m.Status == status);
        }
    }
}
