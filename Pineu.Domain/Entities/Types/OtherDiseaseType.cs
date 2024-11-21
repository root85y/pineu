namespace Pineu.Domain.Entities.Types;

public class OtherDiseaseType : Entity<short> {
    public string EnglishName { get; private set; }
    public string FarsiName { get; private set; }

    private OtherDiseaseType(short id) : base(id) { }

    private OtherDiseaseType(short id, string englishName, string farsiName) : this(id) {
        EnglishName = englishName;
        FarsiName = farsiName;
    }
}