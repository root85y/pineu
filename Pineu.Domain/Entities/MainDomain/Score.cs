namespace Pineu.Domain.Entities.MainDomain;
public class Score : Entity<Guid> {
    public ScoreAction Action { get; private set; }
    public int ScoreCount { get; private set; }

    private Score(Guid id) : base(id) { }
    private Score(Guid id, ScoreAction action, int scoreCount) : this(id) {
        Action = action;
        ScoreCount = scoreCount;
    }
    public void Update(int scoreCount) => ScoreCount = scoreCount;
}
