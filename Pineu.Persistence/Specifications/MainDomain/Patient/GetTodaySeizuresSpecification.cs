namespace Pineu.Persistence.Specifications.MainDomain.Seizures {
    internal class GetTodaySeizuresForDoctorSpecification : Specification<Seizure> {
        private readonly IQueryable<Profile> _profiles;

        public GetTodaySeizuresForDoctorSpecification(Guid doctorId, IQueryable<Profile> profiles) {
            _profiles = profiles;

            Query.Where(s => s.CreatedAt.Date == DateTime.UtcNow.Date)
                 .Where(s => s.UserId != null &&
                             _profiles.Where(p => p.DoctorId == doctorId)
                                      .Select(p => p.UserId)
                                      .Contains(s.UserId))
                 .AsNoTracking();
        }
    }
}
