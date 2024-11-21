namespace Pineu.Domain.Entities.Types;

public class ParentFamilyRelationshipType : Entity<short> {
    public string EnglishName { get; private set; }
    public string FarsiName { get; private set; }
    
    private ParentFamilyRelationshipType(short id) : base(id) { }

    private ParentFamilyRelationshipType(short id, string englishName, string farsiName) : this(id) {
        EnglishName = englishName;
        FarsiName = farsiName;
    }
}