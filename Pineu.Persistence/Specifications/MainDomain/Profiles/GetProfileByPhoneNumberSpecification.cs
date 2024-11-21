namespace Pineu.Persistence.Specifications.MainDomain.Profiles {
    internal class GetProfileByPhoneNumberSpecification : Specification<Profile> {
        public GetProfileByPhoneNumberSpecification(string Phonenumber) {
            Query.Where(m => m.Mobile == Phonenumber);
        }
    }
}
