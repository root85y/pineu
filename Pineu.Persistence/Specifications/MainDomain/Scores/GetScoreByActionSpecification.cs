namespace Pineu.Persistence.Specifications.MainDomain.Scores {
    internal class GetScoreByActionSpecification : Specification<Score> {
        public GetScoreByActionSpecification(ScoreAction action) {
            Query.Where(s => s.Action == action);
        }
    }
}
