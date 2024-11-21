namespace Pineu.Domain.Entities.Types;

public class MovementType : Entity<short> {
    public string EnglishName { get; private set; }
    public string FarsiName { get; private set; }

    private MovementType(short id) : base(id) { }

    private MovementType(short id, string englishName, string farsiName) : this(id) {
        EnglishName = englishName;
        FarsiName = farsiName;
    }
}