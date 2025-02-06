namespace Pineu.Persistence.Specifications.MainDomain.Profiles {
    internal class GetProfileCountSpecification : Specification<Profile> {
        public GetProfileCountSpecification() {
            Query.Where(m => m.Mobile != null);
        }
    }
}
