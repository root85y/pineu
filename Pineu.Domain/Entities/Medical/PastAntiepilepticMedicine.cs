using Pineu.Domain.Entities.Types;

namespace Pineu.Domain.Entities.Medical;

public class PastAntiepilepticMedicine : Entity<Guid> {
    public int? MedicineId { get; private set; }
    public DefaultMedicine? Medicine { get; private set; }
    public Guid? UserMedicineId { get; private set; }
    public UserMedicine? UserMedicine { get; private set; }

    public int? Amount { get; private set; }

    public short? DateTimeUnitTypeId { get; private set; }
    public DateTimeUnitType? DateTimeUnitType { get; private set; }

    public short? DurationOfUseTypeId { get; private set; }
    public DurationOfUseType? DurationOfUseType { get; private set; }

    public DateOnly? StopDate { get; private set; }
    public string? ReasonOfStop { get; private set; }

    public Guid MedicalInformationId { get; private set; }
    public MedicalInformation MedicalInformation { get; private set; }

    private PastAntiepilepticMedicine(Guid id) : base(id) { }

    private PastAntiepilepticMedicine(Guid id, int? medicineId, Guid? userMedicineId, int? amount, short? dateTimeUnitTypeId,
        short? durationOfUseTypeId, DateOnly? stopDate, string? reasonOfStop, Guid medicalInformationId) : this(id) {
        MedicineId = medicineId;
        UserMedicineId = userMedicineId;
        Amount = amount;
        DateTimeUnitTypeId = dateTimeUnitTypeId;
        DurationOfUseTypeId = durationOfUseTypeId;
        StopDate = stopDate;
        ReasonOfStop = reasonOfStop;
        MedicalInformationId = medicalInformationId;
    }

    public static PastAntiepilepticMedicine Create(Guid id, int? medicineId, Guid? userMedicineId, int? amount,
        short? dateTimeUnitTypeId, short? durationOfUseTypeId, DateOnly? stopDate, string? reasonOfStop, Guid medicalInformationId) =>
        new(id, medicineId, userMedicineId, amount, dateTimeUnitTypeId, durationOfUseTypeId, stopDate,
            reasonOfStop, medicalInformationId);

    public void Update(int? medicineId, Guid? userMedicineId, int? amount,
        short? dateTimeUnitTypeId, short? durationOfUseTypeId, DateOnly? stopDate, string? reasonOfStop) {
        MedicineId = medicineId;
        UserMedicineId = userMedicineId;
        Amount = amount;
        DateTimeUnitTypeId = dateTimeUnitTypeId;
        DurationOfUseTypeId = durationOfUseTypeId;
        StopDate = stopDate;
        ReasonOfStop = reasonOfStop;
    }
}