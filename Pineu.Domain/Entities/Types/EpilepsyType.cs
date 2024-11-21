namespace Pineu.Domain.Entities.Types;

public class EpilepsyType : Entity<short> {
    public string EnglishName { get; private set; }
    public string FarsiName { get; private set; }

    private EpilepsyType(short id) : base(id) { }

    private EpilepsyType(short id, string englishName, string farsiName) : this(id) {
        EnglishName = englishName;
        FarsiName = farsiName;
    }
}