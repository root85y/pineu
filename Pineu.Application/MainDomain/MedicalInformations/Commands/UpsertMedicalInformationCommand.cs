namespace Pineu.Application.MainDomain.MedicalInformations.Commands;

public sealed record UpsertMedicalInformationCommand(Guid UserId, UpsertMedicalInformationRequest Value) : ICommand;
public sealed record UpsertMedicalInformationRequest(
    DateTime? DiagnosisDate,
    short? EpilepsyTypeId,
    List<string> SeizureSymptomList,
    int? SeizureSymptomFrequency,
    short? SeizureSymptomFrequencyTypeId,
    List<string> SeizureInjuryList,
    short? EpilepsyConsciousnessTypeId,
    short? EpilepsyMovementTypeId,
    string? EpilepsySecondType,
    short? SeizureTypeId,
    short? SeizureConsciousnessTypeId,
    short? SeizureMovementTypeId,
    string? SeizureSecondType,
    string? EpilepticSyndrome,
    IList<short> AetiologyList,
    string? AetiologyDescription,
    IList<short> OtherDiseaseList,
    IList<PastAntiepilepticMedicineDTO> PastAntiepilepticMedicineList,
    IList<CurrentAntiepilepticMedicineDTO> CurrentAntiepilepticMedicineList,
    IList<OtherMedicineDTO> OtherMedicineList,
    DateTime? EegDate,
    string? EegResult,
    string? PhotoResult,
    DateTime? PhotoDate,
    DateTime? OtherDiagnosticMeasuresDate,
    string? OtherDiagnosticMeasuresResult,
    DateTime? FirstSeizure,
    DateTime? LastSeizure,
    int? YearlySeizureCount,
    int? SeizureInterval,
    short? SeizureTimeUnitTypeId,
    short? ParentFamilyRelationshipTypeId,
    DateTime? HospitalizationDate,
    int? HospitalizationCount,
    int? HospitalizationDuration,
    short? HospitalizationTimeUnitTypeId,
    string? SystemicDisease,
    IList<short> PastYearComplaintList,
    IList<FamilyDiseaseHistoryDTO> FamilyDiseaseHistoryList,
    IList<DrugConsumptionDTO> DrugConsumptionList,
    string? FamilyDescription,
    SystemFileDTO? FaceFile,
    SystemFileDTO? IdCardFile
    );

public sealed record PastAntiepilepticMedicineDTO(
    Guid? Id,
    string MedicineId,
    int? Amount,
    short? DateTimeUnitTypeId,
    short? DurationOfUseTypeId,
    DateTime? StopDate,
    string? ReasonOfStop) : DrugDto(MedicineId);

public sealed record CurrentAntiepilepticMedicineDTO(
    Guid? Id,
    string MedicineId,
    int? Amount,
    short? DateTimeUnitTypeId,
    short? DurationOfUseTypeId,
    string? Complications) : DrugDto(MedicineId);

public sealed record OtherMedicineDTO(
    Guid? Id,
    string MedicineId,
    int? Amount,
    short? DateTimeUnitTypeId,
    short? DurationOfUseTypeId,
    string? Complications) : DrugDto(MedicineId);

public sealed record FamilyDiseaseHistoryDTO(
    Guid? Id,
    short FamilyDiseaseHistoryTypeId,
    string? Name,
    string? Relationship);

public sealed record DrugConsumptionDTO(
    Guid? Id,
    short DrugTypeId,
    int? DailyAmount,
    int? DrugConsumptionDuration,
    short? DateTimeUnitTypeId);

public sealed record SystemFileDTO(
    string? Path, string? Url);

public record DrugDto(string MedicineId);