namespace Pineu.Domain.Entities.MainDomain;

public class DefaultMedicine : Entity<int>
{
    public string Name { get; private set; }
    public MedicineType Type { get; private set; }

    private DefaultMedicine(int id) : base(id) { }

    private DefaultMedicine(int id, string name, MedicineType type) : this(id)
    {
        Name = name;
        Type = type;
    }
}