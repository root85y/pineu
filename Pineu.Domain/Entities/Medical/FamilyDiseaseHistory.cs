using Pineu.Domain.Entities.Types;

namespace Pineu.Domain.Entities.Medical;

public class FamilyDiseaseHistory : Entity<Guid> {
    public short FamilyDiseasesHistoryTypeId { get; private set; }
    public FamilyDiseasesHistoryType FamilyDiseasesHistoryType { get; private set; }

    public string? Name { get; private set; }
    public string? Relationship { get; private set; }

    public Guid MedicalInformationId { get; private set; }
    public MedicalInformation MedicalInformation { get; private set; }

    private FamilyDiseaseHistory(Guid id) : base(id) { }
    private FamilyDiseaseHistory(Guid id, short familyDiseasesHistoryTypeId, string name, string relationship,
        Guid medicalInformationId) : this(id) {
        FamilyDiseasesHistoryTypeId = familyDiseasesHistoryTypeId;
        Name = name;
        Relationship = relationship;
        MedicalInformationId = medicalInformationId;
    }

    public static FamilyDiseaseHistory Create(Guid id, short familyDiseasesHistoryTypeId, string name,
        string relationship, Guid medicalInformationId) =>
        new(id, familyDiseasesHistoryTypeId, name, relationship, medicalInformationId);

    public void Update(short familyDiseasesHistoryTypeId, string name, string relationship) {
        FamilyDiseasesHistoryTypeId = familyDiseasesHistoryTypeId;
        Name = name;
        Relationship = relationship;
    }
}