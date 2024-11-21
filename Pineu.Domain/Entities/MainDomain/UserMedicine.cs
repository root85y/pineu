namespace Pineu.Domain.Entities.MainDomain;

public class UserMedicine : Entity<Guid>
{
    public string Name { get; private set; }
    public MedicineType? Type { get; private set; }
    public Guid UserId { get; private set; }

    private UserMedicine(Guid id) : base(id) {}

    private UserMedicine(Guid id, string name, MedicineType? type, Guid userId) : this(id)
    {
        Name = name;
        Type = type;
        UserId = userId;
    }

    public static UserMedicine Create(Guid id, string name, MedicineType? type, Guid userId) =>
        new(id, name, type, userId);

    public void Update(string name, MedicineType? type)
    {
        Name = name;
        Type = type;
    }
}