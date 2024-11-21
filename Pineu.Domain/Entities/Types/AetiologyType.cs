namespace Pineu.Domain.Entities.Types;

public class AetiologyType : Entity<short> {
    public string EnglishName { get; private set; }
    public string FarsiName { get; private set; }
    private AetiologyType(short id) : base(id) { }

    private AetiologyType(short id, string englishName, string farsiName) : this(id) {
        EnglishName = englishName;
        FarsiName = farsiName;
    }
}