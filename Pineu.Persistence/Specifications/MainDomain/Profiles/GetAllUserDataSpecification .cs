namespace Pineu.Persistence.Specifications.MainDomain.Profiles {
    internal class GetAllUserDataSpecification : Specification<Profile> {
        public GetAllUserDataSpecification() {
            Query.Where(m => m.Status == "Completed");
        }
    }
}
