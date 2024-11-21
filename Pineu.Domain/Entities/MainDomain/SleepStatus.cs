namespace Pineu.Domain.Entities.MainDomain;
public class SleepStatus : Entity<Guid> {
    public SleepStatusEnum Value { get; private set; }
    public DateOnly Date { get; private set; }
    public Guid UserId { get; private set; }
    private SleepStatus(Guid id) : base(id) { }
    private SleepStatus(Guid id, SleepStatusEnum value, DateOnly date, Guid userId) : this(id) {
        Value = value;
        Date = date;
        UserId = userId;
    }
    public static SleepStatus Create(Guid id, SleepStatusEnum value, DateOnly date, Guid userId) =>
        new(id, value, date, userId);
    public void Update(SleepStatusEnum value) => Value = value;
}
