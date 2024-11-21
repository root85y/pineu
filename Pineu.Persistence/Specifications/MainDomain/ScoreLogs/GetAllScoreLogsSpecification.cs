namespace Pineu.Persistence.Specifications.MainDomain.ScoreLogs {
    internal sealed class GetAllScoreLogsSpecification : Specification<ScoreLog> {
        public GetAllScoreLogsSpecification(DateTime? from, DateTime? to, Guid? userId, ScoreType? type) {
            if (from.HasValue && to.HasValue) 
                Query.Where(s => s.CreatedAt.Date >= from.Value.Date && s.CreatedAt.Date <= to.Value.Date);
            if (userId.HasValue)
                Query.Where(s => s.UserId == userId);
            switch (type)
            {
                case ScoreType.Delivered:
                    Query.Where(s => s.Change >= 0);
                    break;
                case ScoreType.Payment:
                    Query.Where(s => s.Change < 0);
                    break;
                case null:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            Query.Include(s => s.Discount).AsNoTracking().OrderByDescending(s => s.CreatedAt);
        }
    }
}
