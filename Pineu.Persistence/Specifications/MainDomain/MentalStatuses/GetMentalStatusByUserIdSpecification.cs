namespace Pineu.Persistence.Specifications.MainDomain.MentalStatuses {
    internal class GetMentalStatusByUserIdSpecification : Specification<MentalStatus> {
        public GetMentalStatusByUserIdSpecification(Guid userId, DateTime? date) {
            if (date.HasValue)
                Query.Where(ms => ms.Date == DateOnly.FromDateTime(date.Value));
            else
                Query.Where(ms => ms.Date == DateOnly.FromDateTime(DateTime.Now));
            Query.Where(ms => ms.UserId == userId);
        }
    }
}
