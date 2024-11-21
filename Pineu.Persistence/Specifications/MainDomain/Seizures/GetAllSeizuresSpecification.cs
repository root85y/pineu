namespace Pineu.Persistence.Specifications.MainDomain.Seizures {
    internal class GetAllSeizuresSpecification : Specification<Seizure> {
        public GetAllSeizuresSpecification(DateTime? from, DateTime? to, Guid? userId) {
            if (from.HasValue && to.HasValue) {
                Query.Where(s => s.SeizureDateTime.Date >= from.Value.Date && s.SeizureDateTime.Date <= to.Value.Date);
            } else {
                Query.Where(s => s.SeizureDateTime.Date >= DateTime.Now.AddDays(-7).Date);
            }
            if (userId.HasValue)
                Query.Where(s => s.UserId == userId);
            Query.AsNoTracking().OrderByDescending(s => s.SeizureDateTime);
        }
    }
}
