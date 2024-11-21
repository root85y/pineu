namespace Pineu.Persistence.Specifications.MainDomain.SleepStatuses {
    internal class GetSleepStatusByUserIdSpecification : Specification<SleepStatus> {
        public GetSleepStatusByUserIdSpecification(Guid userId, DateTime? date) {
            if (date.HasValue)
                Query.Where(ms => ms.Date == DateOnly.FromDateTime(date.Value));
            else
                Query.Where(ms => ms.Date == DateOnly.FromDateTime(DateTime.Now));
            Query.Where(ms => ms.UserId == userId);
        }
    }
}
