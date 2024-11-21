namespace Pineu.Domain.Entities.Types;

public class FamilyDiseasesHistoryType : Entity<short> {
    public string EnglishName { get; private set; }
    public string FarsiName { get; private set; }

    private FamilyDiseasesHistoryType(short id) : base(id) { }

    private FamilyDiseasesHistoryType(short id, string englishName, string farsiName) : this(id) {
        EnglishName = englishName;
        FarsiName = farsiName;
    }
}