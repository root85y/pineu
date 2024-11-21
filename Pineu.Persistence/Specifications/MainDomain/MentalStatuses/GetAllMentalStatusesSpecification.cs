namespace Pineu.Persistence.Specifications.MainDomain.MentalStatuses {
    internal class GetAllMentalStatusesSpecification : Specification<MentalStatus> {
        public GetAllMentalStatusesSpecification(DateTime? from, DateTime? to, Guid? userId) {
            if (from.HasValue && to.HasValue) {
                Query.Where(s => s.Date >= DateOnly.FromDateTime(from.Value) && s.Date <= DateOnly.FromDateTime(to.Value));
            } else {
                Query.Where(s => s.Date >= DateOnly.FromDateTime(DateTime.Now.AddDays(-7)));
            }
            if (userId.HasValue)
                Query.Where(ms => ms.UserId == userId);
            Query.AsNoTracking().OrderByDescending(ms => ms.Date);
        }
    }
}
