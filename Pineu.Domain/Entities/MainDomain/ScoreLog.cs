namespace Pineu.Domain.Entities.MainDomain;
public class ScoreLog : Entity<Guid> {
    public Guid UserId { get; private set; }
    public int Change { get; private set; }
    public int RemainingScore { get; private set; }
    public ScoreAction Action { get; private set; }
    public Guid? DiscountId { get; private set; }
    public Discount? Discount { get; private set; }
    private ScoreLog(Guid id) : base(id) { }
    private ScoreLog(Guid id, Guid userId, int change, int remainingScore, ScoreAction action, Guid? discountId) : this(id) {
        UserId = userId;
        Change = change;
        RemainingScore = remainingScore;
        Action = action;
        DiscountId = discountId;
    }
    public static ScoreLog Create(Guid id, Guid userId, int change, int remainingScore, ScoreAction action, Guid? discountId) =>
        new(id, userId, change, remainingScore, action, discountId);
}
