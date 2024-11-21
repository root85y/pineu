namespace Pineu.Domain.Entities.Types;

public class DrugType : Entity<short> {
    public string EnglishName { get; private set; }
    public string FarsiName { get; private set; }

    private DrugType(short id) : base(id) { }

    private DrugType(short id, string englishName, string farsiName) : this(id) {
        EnglishName = englishName;
        FarsiName = farsiName;
    }
}