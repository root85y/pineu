namespace Pineu.Persistence.Specifications.MainDomain.Seizures {
    internal class GetAllSeizuresCountSpecification : Specification<Seizure> {
        public GetAllSeizuresCountSpecification(DateTime? from, DateTime? to, Guid? doctorId, Profile profiles) {

            if (from.HasValue && to.HasValue) {
                Query.Where(s => s.SeizureDateTime.Date >= from.Value.Date &&
                            s.SeizureDateTime.Date <= to.Value.Date);
            }

            if (doctorId.HasValue) {
                Query.Where(s => s.UserId == profiles.UserId);
                Query.AsNoTracking()
                     .OrderByDescending(s => s.SeizureDateTime);
            }
        }
    }
}
