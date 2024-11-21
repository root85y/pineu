namespace Pineu.Domain.Entities.MainDomain;
public class WorkoutStatus : Entity<Guid> {
    public WorkoutStatusEnum Value { get; private set; }
    public DateOnly Date { get; private set; }
    public Guid UserId { get; private set; }
    private WorkoutStatus(Guid id) : base(id) { }
    private WorkoutStatus(Guid id, WorkoutStatusEnum value, DateOnly date, Guid userId) : this(id) {
        Value = value;
        Date = date;
        UserId = userId;
    }
    public static WorkoutStatus Create(Guid id, WorkoutStatusEnum value, DateOnly date, Guid userId) =>
        new(id, value, date, userId);
    public void Update(WorkoutStatusEnum value) => Value = value;
}
