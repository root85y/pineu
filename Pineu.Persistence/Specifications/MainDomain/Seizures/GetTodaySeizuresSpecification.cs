namespace Pineu.Persistence.Specifications.MainDomain.Seizures {
    internal class GetTodaySeizuresForDoctorSpecification : Specification<Seizure> {
        public GetTodaySeizuresForDoctorSpecification(Guid doctorId, Profile profiles) {

            Query.Where(s => s.CreatedAt.Date == DateTime.UtcNow.Date)
                 .Where(s => s.UserId == profiles.UserId)
                 .AsNoTracking();
        }
    }
}
