namespace Pineu.Domain.Entities.MainDomain;
public class MentalStatus : Entity<Guid> {
    public List<MentalStatusEnum> Value { get; private set; }
    public DateOnly Date { get; private set; }
    public Guid UserId { get; private set; }
    private MentalStatus(Guid id) : base(id) { }
    private MentalStatus(Guid id, List<MentalStatusEnum> value, DateOnly date, Guid userId) : this(id) {
        Value = value;
        Date = date;
        UserId = userId;
    }
    public static MentalStatus Create(Guid id, List<MentalStatusEnum> value, DateOnly date, Guid userId) =>
        new(id, value, date, userId);
    public void Update(List<MentalStatusEnum> value) => Value = value;
}
