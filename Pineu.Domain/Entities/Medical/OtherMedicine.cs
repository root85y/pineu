using Pineu.Domain.Entities.Types;

namespace Pineu.Domain.Entities.Medical;

public class OtherMedicine : Entity<Guid> {
    public int? MedicineId { get; private set; }
    public DefaultMedicine? Medicine { get; private set; }
    public Guid? UserMedicineId { get; private set; }
    public UserMedicine? UserMedicine { get; private set; }

    public int? Amount { get; private set; }

    public short? DateTimeUnitTypeId { get; private set; }
    public DateTimeUnitType? DateTimeUnitType { get; private set; }

    public short? DurationOfUseTypeId { get; private set; }
    public DurationOfUseType? DurationOfUseType { get; private set; }

    public string? Complications { get; private set; }

    public Guid MedicalInformationId { get; private set; }
    public MedicalInformation MedicalInformation { get; private set; }

    private OtherMedicine(Guid id) : base(id) { }
    private OtherMedicine(Guid id, int? medicineId, Guid? userMedicineId, int? amount, short? dateTimeUnitTypeId,
        short? durationOfUseTypeId, string? complications, Guid medicalInformationId) : this(id) {
        MedicineId = medicineId;
        UserMedicineId = userMedicineId;
        Amount = amount;
        DateTimeUnitTypeId = dateTimeUnitTypeId;
        DurationOfUseTypeId = durationOfUseTypeId;
        Complications = complications;
        MedicalInformationId = medicalInformationId;
    }

    public static OtherMedicine Create(Guid id, int? medicineId, Guid? userMedicineId, int? amount,
        short? dateTimeUnitTypeId, short? durationOfUseTypeId, string? complications, Guid medicalInformationId) =>
        new(id, medicineId, userMedicineId, amount, dateTimeUnitTypeId, durationOfUseTypeId, complications,
            medicalInformationId);
    public void Update(int? medicineId, Guid? userMedicineId, int? amount,
        short? dateTimeUnitTypeId, short? durationOfUseTypeId, string? complications) {
        MedicineId = medicineId;
        UserMedicineId = userMedicineId;
        Amount = amount;
        DateTimeUnitTypeId = dateTimeUnitTypeId;
        DurationOfUseTypeId = durationOfUseTypeId;
        Complications = complications;
    }
}