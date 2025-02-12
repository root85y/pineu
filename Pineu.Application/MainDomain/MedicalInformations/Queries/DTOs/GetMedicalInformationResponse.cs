using Pineu.Application.MainDomain.DefaultMedicines.Queries.DTOs;
using Pineu.Application.MainDomain.MedicalInformations.Commands;

namespace Pineu.Application.MainDomain.MedicalInformations.Queries.DTOs;

public sealed record GetMedicalInformationResponse(
    Guid Id,
    DateOnly? DiagnosisDate,
    string? EpilepsyTypeName,
    List<string> SeizureSymptomList,
    int? SeizureSymptomFrequency,
    string? SeizureSymptomFrequencyTypeName,
    List<string> SeizureInjuryList,
    string? EpilepsyConsciousnessTypeName,
    string? EpilepsyMovementTypeName,
    string? EpilepsySecondType,
    string? SeizureTypeName,
    string? SeizureConsciousnessTypeName,
    string? SeizureMovementTypeName,
    string? SeizureSecondType,
    string? EpilepticSyndrome,
    IEnumerable<string> AetiologyList,
    string? AetiologyDescription,
    IEnumerable<string> OtherDiseaseList,
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
    string? SeizureTimeUnitTypeName,
    string? ParentFamilyRelationshipTypeName,
    DateOnly? HospitalizationDate,
    int? HospitalizationCount,
    int? HospitalizationDuration,
    string? HospitalizationTimeUnitTypeName,
    string? SystemicDisease,
    IEnumerable<string> PastYearComplaintList,
    IEnumerable<FamilyDiseaseHistoryDTO> FamilyDiseaseHistoryList,
    IEnumerable<DrugConsumptionDTO> DrugConsumptionList,
    string? FamilyDescription,
    SystemFileDTO? FaceFile,
    SystemFileDTO? IdCardFile);

public sealed record PastAntiepilepticMedicineResponse(
    Guid Id,
    GetDefaultMedicineResponse Medicine,
    int? Amount,
    string? DateTimeUnitTypeName,
    string? DurationOfUseTypeName,
    DateTime? StopDate,
    string? ReasonOfStop);

public sealed record CurrentAntiepilepticMedicineResponse(
    Guid Id,
    GetDefaultMedicineResponse Medicine,
    int? Amount,
    string? DateTimeUnitTypeName,
    string? DurationOfUseTypeName,
    string? Complications);

public sealed record OtherMedicineResponse(
    Guid Id,
    GetDefaultMedicineResponse Medicine,
    int? Amount,
    string? DateTimeUnitTypeName,
    string? DurationOfUseTypeName,
    string? Complications);
