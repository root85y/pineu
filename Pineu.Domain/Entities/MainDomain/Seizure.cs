namespace Pineu.Domain.Entities.MainDomain;
public class Seizure : Entity<Guid> {
    public Guid UserId { get; private set; }
    public DateTime SeizureDateTime { get; private set; }
    public int? SeizureDuration { get; private set; }
    public List<AttackType>? AttackTypeList { get; private set; }
    public List<string>? InjuryList { get; private set; }
    public string? SeverityOfInjury { get; private set; }
    public MentalStatusEnum? MentalStatusBeforeSeizure { get; private set; }
    public AmountType? AmountOfPhysicalStatusBeforeSeizure { get; private set; }
    public List<string>? GeneralStatusBeforeSeizure { get; private set; }
    public QualityType? SleepQualityAtTheNightBeforeSeizure { get; private set; }
    public List<string>? ActivityAtSeizureTime { get; private set; }
    public List<string>? FoodBeforeSeizure { get; private set; }
    public AmountType? AmountOfFoodBeforeSeizure { get; private set; }
    public ConsumptionType? SmokingConsumption { get; private set; }
    public ConsumptionType? AlcoholConsumption { get; private set; }
    public MentalStatusEnum? MentalStatusAfterSeizure { get; private set; }
    public List<string>? GeneralStatusAfterSeizure { get; private set; }
    private Seizure(Guid id) : base(id) { }

    public Seizure(Guid id, Guid userId, DateTime seizureDateTime, int? seizureDuration, List<AttackType>? attackTypeList,
        List<string>? injuryList, string? severityOfInjury, MentalStatusEnum? mentalStatusBeforeSeizure,
        AmountType? amountOfPhysicalStatusBeforeSeizure, List<string>? generalStatusBeforeSeizure,
        QualityType? sleepQualityAtTheNightBeforeSeizure, List<string>? activityAtSeizureTime, List<string>? foodBeforeSeizure,
        AmountType? amountOfFoodBeforeSeizure, ConsumptionType? smokingConsumption, ConsumptionType? alcoholConsumption,
        MentalStatusEnum? mentalStatusAfterSeizure, List<string>? generalStatusAfterSeizure) : this(id) {
        UserId = userId;
        SeizureDateTime = seizureDateTime;
        SeizureDuration = seizureDuration;
        AttackTypeList = attackTypeList;
        InjuryList = injuryList;
        SeverityOfInjury = severityOfInjury;
        MentalStatusBeforeSeizure = mentalStatusBeforeSeizure;
        AmountOfPhysicalStatusBeforeSeizure = amountOfPhysicalStatusBeforeSeizure;
        GeneralStatusBeforeSeizure = generalStatusBeforeSeizure;
        SleepQualityAtTheNightBeforeSeizure = sleepQualityAtTheNightBeforeSeizure;
        ActivityAtSeizureTime = activityAtSeizureTime;
        FoodBeforeSeizure = foodBeforeSeizure;
        AmountOfFoodBeforeSeizure = amountOfFoodBeforeSeizure;
        SmokingConsumption = smokingConsumption;
        AlcoholConsumption = alcoholConsumption;
        MentalStatusAfterSeizure = mentalStatusAfterSeizure;
        GeneralStatusAfterSeizure = generalStatusAfterSeizure;
    }

    public static Seizure Create(Guid id, Guid userId, DateTime seizureDateTime, int? seizureDuration, List<AttackType>? attackTypeList,
        List<string>? injuryList, string? severityOfInjury, MentalStatusEnum? mentalStatusBeforeSeizure,
        AmountType? amountOfPhysicalStatusBeforeSeizure, List<string>? generalStatusBeforeSeizure,
        QualityType? sleepQualityAtTheNightBeforeSeizure, List<string>? activityAtSeizureTime, List<string>? foodBeforeSeizure,
        AmountType? amountOfFoodBeforeSeizure, ConsumptionType? smokingConsumption, ConsumptionType? alcoholConsumption,
        MentalStatusEnum? mentalStatusAfterSeizure, List<string>? generalStatusAfterSeizure) =>
        new(id, userId, seizureDateTime, seizureDuration, attackTypeList, injuryList, severityOfInjury, mentalStatusBeforeSeizure,
            amountOfPhysicalStatusBeforeSeizure, generalStatusBeforeSeizure, sleepQualityAtTheNightBeforeSeizure, activityAtSeizureTime,
            foodBeforeSeizure, amountOfFoodBeforeSeizure, smokingConsumption, alcoholConsumption, mentalStatusAfterSeizure,
            generalStatusAfterSeizure);
}
