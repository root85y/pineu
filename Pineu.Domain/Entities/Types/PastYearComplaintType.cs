namespace Pineu.Domain.Entities.Types;

public class PastYearComplaintType : Entity<short> {
    public string EnglishName { get; private set; }
    public string FarsiName { get; private set; }
    private PastYearComplaintType(short id) : base(id) { }

    private PastYearComplaintType(short id, string englishName, string farsiName) : this(id) {
        EnglishName = englishName;
        FarsiName = farsiName;
    }
}