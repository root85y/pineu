namespace Pineu.Persistence.Specifications.MainDomain.Seizures {
    internal class GetAllSeizuresCountSpecification : Specification<Seizure> {
        private readonly IQueryable<Profile> _profiles;


        public GetAllSeizuresCountSpecification(DateTime? from, DateTime? to, Guid? doctorId, IQueryable<Profile> profiles) {
            _profiles = profiles;

            if (from.HasValue && to.HasValue) {
                Query.Where(s => s.SeizureDateTime.Date >= from.Value.Date && s.SeizureDateTime.Date <= to.Value.Date);
            }

            if (doctorId.HasValue) {
                var userIds = profiles.Where(p => p.DoctorId == doctorId).Select(p => p.UserId);
                Query.Where(s => userIds.Contains(s.UserId));
                Query.AsNoTracking().OrderByDescending(s => s.SeizureDateTime);
            }
        }
    }
}
