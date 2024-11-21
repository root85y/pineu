namespace Pineu.Domain.Entities.Types;

public class DurationOfUseType : Entity<short> {
    public string EnglishName { get; private set; }
    public string FarsiName { get; private set; }

    private DurationOfUseType(short id) : base(id) { }

    private DurationOfUseType(short id, string englishName, string farsiName) : this(id) {
        EnglishName = englishName;
        FarsiName = farsiName;
    }
}