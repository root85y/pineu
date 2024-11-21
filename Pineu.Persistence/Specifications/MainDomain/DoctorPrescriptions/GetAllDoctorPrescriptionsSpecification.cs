namespace Pineu.Persistence.Specifications.MainDomain.DoctorPrescriptions {
    internal class GetAllDoctorPrescriptionsSpecification : Specification<DoctorPrescription> {
        public GetAllDoctorPrescriptionsSpecification(DateTime? from, DateTime? to, Guid userId) {
            if (from.HasValue && to.HasValue) {
                Query.Where(s => s.VisitedAt.Date >= from.Value.Date && s.VisitedAt.Date <= to.Value.Date);
            } else {
                Query.Where(s => s.VisitedAt >= DateTime.Now.AddDays(-7));
            }
            Query.Where(dp => dp.UserId == userId).AsNoTracking().OrderByDescending(dp => dp.VisitedAt);
        }
    }
}
