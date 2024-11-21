namespace Pineu.Domain.Entities.Types;

public class DateTimeUnitType : Entity<short> {
    public string EnglishName { get; private set; }
    public string FarsiName { get; private set; }

    private DateTimeUnitType(short id) : base(id) { }

    private DateTimeUnitType(short id, string englishName, string farsiName) : this(id) {
        EnglishName = englishName;
        FarsiName = farsiName;
    }
}