namespace Pineu.Persistence.Specifications.MainDomain.Seizures {
    internal class HasSubmittedTooManySeizuresSpecification : Specification<Seizure> {
        public HasSubmittedTooManySeizuresSpecification() {
            Query.Where(s => s.CreatedAt.Date == DateTime.Now.Date).AsNoTracking();
        }
    }
}
