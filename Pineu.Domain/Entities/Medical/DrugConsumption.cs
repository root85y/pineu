using Pineu.Domain.Entities.Types;

namespace Pineu.Domain.Entities.Medical;

public class DrugConsumption : Entity<Guid> {
    public short DrugTypeId { get; private set; }
    public DrugType DrugType { get; private set; }

    public int? DailyAmount { get; private set; }
    public int? DrugConsumptionDuration { get; private set; }

    public short? DateTimeUnitTypeId { get; private set; }
    public DateTimeUnitType? DateTimeUnitType { get; private set; }

    public Guid MedicalInformationId { get; private set; }
    public MedicalInformation MedicalInformation { get; private set; }

    private DrugConsumption(Guid id) : base(id) { }
    private DrugConsumption(Guid id, short drugTypeId, int? dailyAmount, int? drugConsumptionDuration, short? dateTimeUnitTypeId,
        Guid medicalInformationId) : this(id) {
        DrugTypeId = drugTypeId;
        DailyAmount = dailyAmount;
        DrugConsumptionDuration = drugConsumptionDuration;
        DateTimeUnitTypeId = dateTimeUnitTypeId;
        MedicalInformationId = medicalInformationId;
    }

    public static DrugConsumption Create(Guid id, short drugTypeId, int? dailyAmount, int? drugConsumptionDuration,
        short? dateTimeUnitTypeId,
        Guid medicalInformationId) => new(id, drugTypeId, dailyAmount, drugConsumptionDuration, dateTimeUnitTypeId,
        medicalInformationId);

    public void Update(short drugTypeId, int? dailyAmount, int? drugConsumptionDuration, short? dateTimeUnitTypeId) {
        DrugTypeId = drugTypeId;
        DailyAmount = dailyAmount;
        DrugConsumptionDuration = drugConsumptionDuration;
        DateTimeUnitTypeId = dateTimeUnitTypeId;
    }
}