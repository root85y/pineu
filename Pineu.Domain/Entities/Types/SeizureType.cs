namespace Pineu.Domain.Entities.Types;

public class SeizureType : Entity<short> {
    public string EnglishName { get; private set; }
    public string FarsiName { get; private set; }
    private SeizureType(short id) : base(id) { }

    private SeizureType(short id, string englishName, string farsiName) : this(id) {
        EnglishName = englishName;
        FarsiName = farsiName;
    }
}