namespace Pineu.Persistence.Specifications.MainDomain.Profiles {
    internal class GetProfileByUserIdSpecification : Specification<Profile> {
        public GetProfileByUserIdSpecification(Guid userId) {
            Query.Where(m => m.UserId == userId);
        }
    }
}
