using Pineu.Application.MainDomain.DefaultMedicines.Queries.DTOs;
using Pineu.Application.MainDomain.MedicalInformations.Commands;

namespace Pineu.Application.MainDomain.MedicalInformations.Queries.DTOs;

public sealed record GetMedicalInformationResponse(
    Guid Id,
    DateOnly? DiagnosisDate,
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
    IEnumerable<short> AetiologyList,
    string? AetiologyDescription, 
    IEnumerable<short> OtherDiseaseList,
    IEnumerable<PastAntiepilepticMedicineResponse> PastAntiepilepticMedicineList,
    IEnumerable<CurrentAntiepilepticMedicineResponse> CurrentAntiepilepticMedicineList,
    IEnumerable<OtherMedicineResponse> OtherMedicineList,
    DateOnly? EegDate,
    string? EegResult,
    string? PhotoResult, 
    DateOnly? PhotoDate, 
    DateOnly? OtherDiagnosticMeasuresDate,
    string? OtherDiagnosticMeasuresResult,
    DateOnly? FirstSeizure,
    DateOnly? LastSeizure,
    int? YearlySeizureCount,
    int? SeizureInterval,
    short? SeizureTimeUnitTypeId,
    short? ParentFamilyRelationshipTypeId,
    DateOnly? HospitalizationDate,
    int? HospitalizationCount, 
    int? HospitalizationDuration,
    short? HospitalizationTimeUnitTypeId,
    string? SystemicDisease,
    IEnumerable<short> PastYearComplaintList,
    IEnumerable<FamilyDiseaseHistoryDTO> FamilyDiseaseHistoryList,
    IEnumerable<DrugConsumptionDTO> DrugConsumptionList,
    string? FamilyDescription,
    SystemFileDTO? FaceFile,
    SystemFileDTO? IdCardFile);

public sealed record PastAntiepilepticMedicineResponse(
    Guid Id,
    GetDefaultMedicineResponse Medicine,
    int? Amount,
    short? DateTimeUnitTypeId,
    short? DurationOfUseTypeId,
    DateTime? StopDate,
    string? ReasonOfStop);

public sealed record CurrentAntiepilepticMedicineResponse(
    Guid Id,
    GetDefaultMedicineResponse Medicine,
    int? Amount,
    short? DateTimeUnitTypeId,
    short? DurationOfUseTypeId,
    string? Complications);

public sealed record OtherMedicineResponse(
    Guid Id,
    GetDefaultMedicineResponse Medicine,
    int? Amount,
    short? DateTimeUnitTypeId,
    short? DurationOfUseTypeId,
    string? Complications);

