namespace Pineu.Domain.Entities.Types;

public class ConsciousnessType : Entity<short> {
    public string EnglishName { get; private set; }
    public string FarsiName { get; private set; }

    private ConsciousnessType(short id) : base(id) { }

    private ConsciousnessType(short id, string englishName, string farsiName) : this(id) {
        EnglishName = englishName;
        FarsiName = farsiName;
    }
}