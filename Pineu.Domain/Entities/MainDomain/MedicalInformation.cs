using Pineu.Domain.Entities.Medical;
using Pineu.Domain.Entities.Types;

namespace Pineu.Domain.Entities.MainDomain;
public class MedicalInformation : Entity<Guid> {
    public Guid UserId { get; private set; }
    public DateOnly? DiagnosisDate { get; private set; }

    public short? EpilepsyTypeId { get; private set; }
    public EpilepsyType? EpilepsyType { get; private set; }

    public short? EpilepsyConsciousnessTypeId { get; private set; }
    public ConsciousnessType? EpilepsyConsciousnessType { get; private set; }
    
    public short? EpilepsyMovementTypeId { get; private set; }
    public MovementType? EpilepsyMovementType { get; private set; }

    public string? EpilepsySecondType { get; private set; }

    public short? SeizureTypeId { get; private set; }
    public SeizureType? SeizureType { get; private set; }

    public short? SeizureConsciousnessTypeId { get; private set; }
    public ConsciousnessType? SeizureConsciousnessType { get; private set; }
    
    public short? SeizureMovementTypeId { get; private set; }
    public MovementType? SeizureMovementType { get; private set; }

    public string? SeizureSecondType { get; private set; }
    public List<string> SeizureSymptoms { get; private set; }
    public int? SeizureSymptomFrequency { get; private set; }

    public short? SeizureSymptomFrequencyTypeId { get; private set; }
    public DateTimeUnitType? SeizureSymptomFrequencyType { get; private set; }
    
    public string? EpilepticSyndrome { get; private set; }
    public IList<AetiologyType> Aetiologies { get; private set; }
    public string? AetiologyDescription { get; private set; }
    public IList<OtherDiseaseType> OtherDisease { get; private set; }
    public List<string> SeizureInjuryList { get; private set; }
    public ICollection<PastAntiepilepticMedicine> PastAntiepilepticMedicines { get; private set; }
    public IList<CurrentAntiepilepticMedicine> CurrentAntiepilepticMedicines { get; private set; }
    public IList<OtherMedicine> OtherMedicines { get; private set; }
    public DateOnly? EegDate { get; private set; }
    public string? EegResult { get; private set; }
    public string? PhotoResult { get; private set; }
    public DateOnly? PhotoDate { get; private set; }
    public DateOnly? OtherDiagnosticMeasuresDate { get; private set; }
    public string? OtherDiagnosticMeasuresResult { get; private set; }
    public DateOnly? FirstSeizure { get; private set; }
    public DateOnly? LastSeizure { get; private set; }
    public int? YearlySeizureCount { get; private set; }
    public int? SeizureInterval { get; private set; }

    public short? SeizureTimeUnitId { get; private set; }
    public DateTimeUnitType? SeizureTimeUnit { get; private set; }

    public short? ParentFamilyRelationshipId { get; private set; }
    public ParentFamilyRelationshipType? ParentFamilyRelationship { get; private set; }

    public DateOnly? HospitalizationDate { get; private set; }
    public int? HospitalizationCount { get; private set; }
    public int? HospitalizationDuration { get; private set; }

    public short? HospitalizationTimeUnitId { get; private set; }
    public DateTimeUnitType? HospitalizationTimeUnit { get; private set; }

    public string? SystemicDisease { get; private set; }
    public IList<PastYearComplaintType> PastYearComplaints { get; private set; }
    public IList<FamilyDiseaseHistory> FamilyDiseaseHistory { get; private set; }
    public IList<DrugConsumption> DrugConsumption { get; private set; }
    public string? FamilyDescription { get; private set; }

    public string? FaceFilePath { get; private set; }
    public string? FaceFileUrl { get; private set; }
    public string? IdCardFilePath { get; private set; }
    public string? IdCardFileUrl { get; private set; }

    // TODO: delete later
    public bool? MedicationStatus { get; private set; }
    public string? MedicineAvoidance { get; private set; }
    public List<string>? MedicineList { get; private set; }
    public List<string>? OtherDiseaseList { get; private set; }
    //----------------------------------------------------------

    private MedicalInformation(Guid id) : base(id) { }
    private MedicalInformation(
        Guid id,
        Guid userId,
        DateOnly? diagnosisDate,
        short? epilepsyTypeId,
        List<string> seizureSymptoms,
        int? seizureSymptomFrequency,
        short? seizureSymptomFrequencyTypeId,
        List<string> seizureInjuryList,
        short? epilepsyConsciousnessTypeId,
        short? epilepsyMovementTypeId,
        string? epilepsySecondType,
        short? seizureTypeId,
        short? seizureConsciousnessTypeId,
        short? seizureMovementTypeId,
        string? seizureSecondType,
        string? epilepticSyndrome,
        IList<AetiologyType> aetiologies,
        string? aetiologyDescription,
        IList<OtherDiseaseType> otherDisease,
        ICollection<PastAntiepilepticMedicine> pastAntiepilepticMedicines,
        IList<CurrentAntiepilepticMedicine> currentAntiepilepticMedicines,
        IList<OtherMedicine> otherMedicines,
        DateOnly? eegDate,
        string? eegResult,
        string? photoResult,
        DateOnly? photoDate,
        DateOnly? otherDiagnosticMeasuresDate,
        string? otherDiagnosticMeasuresResult,
        DateOnly? firstSeizure,
        DateOnly? lastSeizure,
        int? yearlySeizureCount,
        int? seizureInterval,
        short? seizureTimeUnitId,
        short? parentFamilyRelationshipId,
        DateOnly? hospitalizationDate,
        int? hospitalizationCount, 
        int? hospitalizationDuration,
        short? hospitalizationTimeUnitId,
        string? systemicDisease,
        IList<PastYearComplaintType> pastYearComplaints,
        IList<FamilyDiseaseHistory> familyDiseaseHistory,
        IList<DrugConsumption> drugConsumption, 
        string? familyDescription,
        string? faceFilePath,
        string? faceFileUrl,
        string? idCardFilePath,
        string? idCardFileUrl) : this(id) {

        UserId = userId;
        DiagnosisDate = diagnosisDate;
        //MedicationStatus = medicationStatus;
        //MedicineAvoidance = medicineAvoidance;
        //MedicineList = medicineList;
        EpilepsyTypeId = epilepsyTypeId;
        SeizureSymptoms = seizureSymptoms;
        SeizureSymptomFrequency = seizureSymptomFrequency;
        SeizureSymptomFrequencyTypeId = seizureSymptomFrequencyTypeId;
        //OtherDiseaseList = otherDiseaseList;
        SeizureInjuryList = seizureInjuryList;
        EpilepsyConsciousnessTypeId = epilepsyConsciousnessTypeId;
        EpilepsyMovementTypeId = epilepsyMovementTypeId;
        EpilepsySecondType = epilepsySecondType;
        SeizureTypeId = seizureTypeId;
        SeizureConsciousnessTypeId = seizureConsciousnessTypeId;
        SeizureMovementTypeId = seizureMovementTypeId;
        SeizureSecondType = seizureSecondType;
        EpilepticSyndrome = epilepticSyndrome;
        Aetiologies = aetiologies;
        AetiologyDescription = aetiologyDescription;
        OtherDisease = otherDisease;
        PastAntiepilepticMedicines = pastAntiepilepticMedicines;
        CurrentAntiepilepticMedicines = currentAntiepilepticMedicines;
        OtherMedicines = otherMedicines;
        EegDate = eegDate;
        EegResult = eegResult;
        PhotoResult = photoResult;
        PhotoDate = photoDate;
        OtherDiagnosticMeasuresDate = otherDiagnosticMeasuresDate;
        OtherDiagnosticMeasuresResult = otherDiagnosticMeasuresResult;
        FirstSeizure = firstSeizure;
        LastSeizure = lastSeizure;
        YearlySeizureCount = yearlySeizureCount;
        SeizureInterval = seizureInterval;
        SeizureTimeUnitId = seizureTimeUnitId;
        ParentFamilyRelationshipId = parentFamilyRelationshipId;
        HospitalizationDate = hospitalizationDate;
        HospitalizationCount = hospitalizationCount;
        HospitalizationDuration = hospitalizationDuration;
        HospitalizationTimeUnitId = hospitalizationTimeUnitId;
        SystemicDisease = systemicDisease;
        PastYearComplaints = pastYearComplaints;
        FamilyDiseaseHistory = familyDiseaseHistory;
        DrugConsumption = drugConsumption;
        FamilyDescription = familyDescription;
        FaceFilePath = faceFilePath;
        FaceFileUrl = faceFileUrl;
        IdCardFilePath = idCardFilePath;
        IdCardFileUrl = idCardFileUrl;
    }

    public static MedicalInformation Create(Guid id,
        Guid userId,
        DateOnly? diagnosisDate,
        short? epilepsyTypeId,
        List<string> seizureSymptoms, 
        int? seizureSymptomFrequency,
        short? seizureSymptomFrequencyTypeId,
        List<string> seizureInjuryList,
        short? epilepsyConsciousnessTypeId,
        short? epilepsyMovementTypeId,
        string? epilepsySecondType,
        short? seizureTypeId,
        short? seizureConsciousnessTypeId,
        short? seizureMovementTypeId,
        string? seizureSecondType,
        string? epilepticSyndrome,
        IList<AetiologyType> aetiologies,
        string? aetiologyDescription, 
        IList<OtherDiseaseType> otherDisease,
        ICollection<PastAntiepilepticMedicine> pastAntiepilepticMedicines,
        IList<CurrentAntiepilepticMedicine> currentAntiepilepticMedicines,
        IList<OtherMedicine> otherMedicines,
        DateOnly? eegDate,
        string? eegResult,
        string? photoResult, 
        DateOnly? photoDate, 
        DateOnly? otherDiagnosticMeasuresDate,
        string? otherDiagnosticMeasuresResult,
        DateOnly? firstSeizure,
        DateOnly? lastSeizure,
        int? yearlySeizureCount,
        int? seizureInterval,
        short? seizureTimeUnitId,
        short? parentFamilyRelationshipId,
        DateOnly? hospitalizationDate,
        int? hospitalizationCount, 
        int? hospitalizationDuration,
        short? hospitalizationTimeUnitId,
        string? systemicDisease,
        IList<PastYearComplaintType> pastYearComplaints,
        IList<FamilyDiseaseHistory> familyDiseaseHistory,
        IList<DrugConsumption> drugConsumption,
        string? familyDescription,
        string? faceFilePath,
        string? faceFileUrl,
        string? idCardFilePath,
        string? idCardFileUrl) =>
        new(id, userId, diagnosisDate, epilepsyTypeId, seizureSymptoms, seizureSymptomFrequency, seizureSymptomFrequencyTypeId,
            seizureInjuryList, epilepsyConsciousnessTypeId, epilepsyMovementTypeId, epilepsySecondType, seizureTypeId,
            seizureConsciousnessTypeId, seizureMovementTypeId, seizureSecondType, epilepticSyndrome, aetiologies,
            aetiologyDescription, otherDisease, pastAntiepilepticMedicines, currentAntiepilepticMedicines, otherMedicines,
            eegDate, eegResult, photoResult, photoDate, otherDiagnosticMeasuresDate, otherDiagnosticMeasuresResult, firstSeizure,
            lastSeizure, yearlySeizureCount, seizureInterval, seizureTimeUnitId, parentFamilyRelationshipId, hospitalizationDate,
            hospitalizationCount, hospitalizationDuration, hospitalizationTimeUnitId, systemicDisease, pastYearComplaints,
            familyDiseaseHistory, drugConsumption, familyDescription, faceFilePath, faceFileUrl, idCardFilePath, idCardFileUrl);

    public void Update(DateOnly? diagnosisDate,
        short? epilepsyTypeId,
        List<string> seizureSymptoms,
        int? seizureSymptomFrequency,
        short? seizureSymptomFrequencyTypeId,
        List<string> seizureInjuryList,
        short? epilepsyConsciousnessTypeId,
        short? epilepsyMovementTypeId,
        string? epilepsySecondType,
        short? seizureTypeId,
        short? seizureConsciousnessTypeId,
        short? seizureMovementTypeId,
        string? seizureSecondType,
        string? epilepticSyndrome,
        IList<AetiologyType> aetiologies,
        string? aetiologyDescription,
        IList<OtherDiseaseType> otherDisease,
        //ICollection<PastAntiepilepticMedicine> pastAntiepilepticMedicines,
        //IList<CurrentAntiepilepticMedicine> currentAntiepilepticMedicines,
        //IList<OtherMedicine> otherMedicines,
        DateOnly? eegDate,
        string? eegResult,
        string? photoResult, 
        DateOnly? photoDate, 
        DateOnly? otherDiagnosticMeasuresDate,
        string? otherDiagnosticMeasuresResult,
        DateOnly? firstSeizure,
        DateOnly? lastSeizure,
        int? yearlySeizureCount,
        int? seizureInterval,
        short? seizureTimeUnitId,
        short? parentFamilyRelationshipId,
        DateOnly? hospitalizationDate,
        int? hospitalizationCount, 
        int? hospitalizationDuration,
        short? hospitalizationTimeUnitId,
        string? systemicDisease,
        IList<PastYearComplaintType> pastYearComplaints,
        //IList<FamilyDiseaseHistory> familyDiseaseHistory,
        //IList<DrugConsumption> drugConsumption, 
        string? familyDescription,
        string? faceFilePath,
        string? faceFileUrl,
        string? idCardFilePath,
        string? idCardFileUrl) {
        DiagnosisDate = diagnosisDate;
        //MedicationStatus = medicationStatus;
        //MedicineAvoidance = medicineAvoidance;
        //MedicineList = medicineList;
        EpilepsyTypeId = epilepsyTypeId;
        SeizureSymptoms = seizureSymptoms;
        SeizureSymptomFrequency = seizureSymptomFrequency;
        SeizureSymptomFrequencyTypeId = seizureSymptomFrequencyTypeId;
        //OtherDiseaseList = otherDiseaseList;
        SeizureInjuryList = seizureInjuryList;
        EpilepsyConsciousnessTypeId = epilepsyConsciousnessTypeId;
        EpilepsyMovementTypeId = epilepsyMovementTypeId;
        EpilepsySecondType = epilepsySecondType;
        SeizureTypeId = seizureTypeId;
        SeizureConsciousnessTypeId = seizureConsciousnessTypeId;
        SeizureMovementTypeId = seizureMovementTypeId;
        SeizureSecondType = seizureSecondType;
        EpilepticSyndrome = epilepticSyndrome;
        Aetiologies = aetiologies;
        AetiologyDescription = aetiologyDescription;
        OtherDisease = otherDisease;
        //PastAntiepilepticMedicines = pastAntiepilepticMedicines;
        //CurrentAntiepilepticMedicines = currentAntiepilepticMedicines;
        //OtherMedicines = otherMedicines;
        EegDate = eegDate;
        EegResult = eegResult;
        PhotoResult = photoResult;
        PhotoDate = photoDate;
        OtherDiagnosticMeasuresDate = otherDiagnosticMeasuresDate;
        OtherDiagnosticMeasuresResult = otherDiagnosticMeasuresResult;
        FirstSeizure = firstSeizure;
        LastSeizure = lastSeizure;
        YearlySeizureCount = yearlySeizureCount;
        SeizureInterval = seizureInterval;
        SeizureTimeUnitId = seizureTimeUnitId;
        ParentFamilyRelationshipId = parentFamilyRelationshipId;
        HospitalizationDate = hospitalizationDate;
        HospitalizationCount = hospitalizationCount;
        HospitalizationDuration = hospitalizationDuration;
        HospitalizationTimeUnitId = hospitalizationTimeUnitId;
        SystemicDisease = systemicDisease;
        PastYearComplaints = pastYearComplaints;
        //FamilyDiseaseHistory = familyDiseaseHistory;
        //DrugConsumption = drugConsumption;
        FamilyDescription = familyDescription;
        FaceFilePath = faceFilePath;
        FaceFileUrl = faceFileUrl;
        IdCardFilePath = idCardFilePath;
        IdCardFileUrl = idCardFileUrl;
    }
}
