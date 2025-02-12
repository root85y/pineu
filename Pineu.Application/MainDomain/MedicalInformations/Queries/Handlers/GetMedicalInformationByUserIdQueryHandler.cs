using Pineu.Application.MainDomain.DefaultMedicines.Queries.DTOs;
using Pineu.Application.MainDomain.MedicalInformations.Commands;
using Pineu.Application.MainDomain.MedicalInformations.Queries.DTOs;

namespace Pineu.Application.MainDomain.MedicalInformations.Queries.Handlers {
    internal class GetMedicalInformationByUserIdQueryHandler(IMedicalInformationRepository repository)
        : IQueryHandler<GetMedicalInformationByUserIdQuery, GetMedicalInformationResponse> {
        public async Task<Result<GetMedicalInformationResponse>> Handle(GetMedicalInformationByUserIdQuery request, CancellationToken cancellationToken) {
            var medicalInfo = await repository.GetAsync(request.UserId, cancellationToken);
            if (medicalInfo == null) return Result.Failure<GetMedicalInformationResponse>(DomainErrors.MedicalInformation.MedicalInformationNotFound);

            //return new GetMedicalInformationResponse(
            //    medicalInfo.Id,
            //    medicalInfo.DiagnosisDate,
            //    medicalInfo.EpilepsyType?.Name,
            //    medicalInfo.SeizureSymptoms,
            //    medicalInfo.SeizureSymptomFrequency,
            //    medicalInfo.SeizureSymptomFrequencyTypeId,
            //    medicalInfo.SeizureInjuryList,
            //    medicalInfo.EpilepsyConsciousnessTypeId,
            //    medicalInfo.EpilepsyMovementTypeId,
            //    medicalInfo.EpilepsySecondType,
            //    medicalInfo.SeizureTypeId,
            //    medicalInfo.SeizureConsciousnessTypeId,
            //    medicalInfo.SeizureMovementTypeId,
            //    medicalInfo.SeizureSecondType,
            //    medicalInfo.EpilepticSyndrome,
            //    medicalInfo.Aetiologies.Select(a => a.Id),
            //    medicalInfo.AetiologyDescription,
            //    medicalInfo.OtherDisease.Select(od => od.Id),
            //    medicalInfo.PastAntiepilepticMedicines.Select(pam => 
            //        new PastAntiepilepticMedicineResponse(
            //            pam.Id,
            //            pam.MedicineId.HasValue ? 
            //                new GetDefaultMedicineResponse(
            //                    pam.Medicine.Id.ToString(),
            //                    pam.Medicine.Name,
            //                    pam.Medicine.Type) :
            //                new GetDefaultMedicineResponse(
            //                    pam.UserMedicine.Id.ToString(),
            //                    pam.UserMedicine.Name,
            //                    pam.UserMedicine.Type),
            //            pam.Amount,
            //            pam.DateTimeUnitTypeId,
            //            pam.DurationOfUseTypeId,
            //            pam.StopDate?.ToDateTime(TimeOnly.MinValue),
            //            pam.ReasonOfStop)
            //    ),
            //    medicalInfo.CurrentAntiepilepticMedicines.Select(cam => 
            //        new CurrentAntiepilepticMedicineResponse(
            //            cam.Id,
            //            cam.MedicineId.HasValue ? 
            //                new GetDefaultMedicineResponse(
            //                    cam.Medicine.Id.ToString(),
            //                    cam.Medicine.Name,
            //                    cam.Medicine.Type) :
            //                new GetDefaultMedicineResponse(
            //                    cam.UserMedicine.Id.ToString(),
            //                    cam.UserMedicine.Name,
            //                    cam.UserMedicine.Type),
            //            cam.Amount,
            //            cam.DateTimeUnitTypeId,
            //            cam.DurationOfUseTypeId,
            //            cam.Complications)
            //    ),
            //    medicalInfo.OtherMedicines.Select(om => 
            //        new OtherMedicineResponse(
            //            om.Id,
            //            om.MedicineId.HasValue ? 
            //                new GetDefaultMedicineResponse(
            //                    om.Medicine.Id.ToString(),
            //                    om.Medicine.Name,
            //                    om.Medicine.Type) :
            //                new GetDefaultMedicineResponse(
            //                    om.UserMedicine.Id.ToString(),
            //                    om.UserMedicine.Name,
            //                    om.UserMedicine.Type),
            //            om.Amount,
            //            om.DateTimeUnitTypeId,
            //            om.DurationOfUseTypeId,
            //            om.Complications)
            //    ),
            //    medicalInfo.EegDate,
            //    medicalInfo.EegResult,
            //    medicalInfo.PhotoResult,
            //    medicalInfo.PhotoDate,
            //    medicalInfo.OtherDiagnosticMeasuresDate,
            //    medicalInfo.OtherDiagnosticMeasuresResult,
            //    medicalInfo.FirstSeizure,
            //    medicalInfo.LastSeizure,
            //    medicalInfo.YearlySeizureCount,
            //    medicalInfo.SeizureInterval,
            //    medicalInfo.SeizureTimeUnitId,
            //    medicalInfo.ParentFamilyRelationshipId,
            //    medicalInfo.HospitalizationDate,
            //    medicalInfo.HospitalizationCount,
            //    medicalInfo.HospitalizationDuration,
            //    medicalInfo.HospitalizationTimeUnitId,
            //    medicalInfo.SystemicDisease,
            //    medicalInfo.PastYearComplaints.Select(pyc => pyc.Id),
            //    medicalInfo.FamilyDiseaseHistory.Select(fdh => 
            //        new FamilyDiseaseHistoryDTO(
            //            fdh.Id, fdh.FamilyDiseasesHistoryTypeId,
            //            fdh.Name, fdh.Relationship)
            //    ),
            //    medicalInfo.DrugConsumption.Select(dc => 
            //        new DrugConsumptionDTO(
            //            dc.Id,
            //            dc.DrugTypeId,
            //            dc.DailyAmount,
            //            dc.DrugConsumptionDuration,
            //            dc.DateTimeUnitTypeId)
            //    ),
            //    medicalInfo.FamilyDescription,
            //    new SystemFileDTO(medicalInfo.FaceFilePath, medicalInfo.FaceFileUrl),
            //    new SystemFileDTO(medicalInfo.IdCardFilePath, medicalInfo.IdCardFileUrl)
            //    );
            return new GetMedicalInformationResponse(
            medicalInfo.Id,
            medicalInfo.DiagnosisDate,
            medicalInfo.EpilepsyType?.FarsiName,
            medicalInfo.SeizureSymptoms,
            medicalInfo.SeizureSymptomFrequency,
            medicalInfo.SeizureSymptomFrequencyType?.FarsiName,
            medicalInfo.SeizureInjuryList,
            medicalInfo.EpilepsyConsciousnessType?.FarsiName,
            medicalInfo.EpilepsyMovementType?.FarsiName,
            medicalInfo.EpilepsySecondType,
            medicalInfo.SeizureType?.FarsiName,
            medicalInfo.SeizureConsciousnessType?.FarsiName,
            medicalInfo.SeizureMovementType?.FarsiName,
            medicalInfo.SeizureSecondType,
            medicalInfo.EpilepticSyndrome,
            medicalInfo.Aetiologies.Select(a => a.FarsiName), 
            medicalInfo.AetiologyDescription,
            medicalInfo.OtherDisease.Select(od => od.FarsiName), 
            medicalInfo.PastAntiepilepticMedicines.Select(pam =>
                new PastAntiepilepticMedicineResponse(
                    pam.Id,
                    new GetDefaultMedicineResponse(
                        pam.Medicine?.Id.ToString() ?? pam.UserMedicine?.Id.ToString(),
                        pam.Medicine?.Name ?? pam.UserMedicine?.Name,
                        pam.Medicine?.Type ?? pam.UserMedicine?.Type),
                    pam.Amount,
                    pam.DateTimeUnitType?.FarsiName,
                    pam.DurationOfUseType?.FarsiName,
                    pam.StopDate?.ToDateTime(TimeOnly.MinValue),
                    pam.ReasonOfStop)
            ),
            medicalInfo.CurrentAntiepilepticMedicines.Select(cam =>
                new CurrentAntiepilepticMedicineResponse(
                    cam.Id,
                    new GetDefaultMedicineResponse(
                        cam.Medicine?.Id.ToString() ?? cam.UserMedicine?.Id.ToString(),
                        cam.Medicine?.Name ?? cam.UserMedicine?.Name,
                        cam.Medicine?.Type ?? cam.UserMedicine?.Type),
                    cam.Amount,
                    cam.DateTimeUnitType?.FarsiName, 
                    cam.DurationOfUseType?.FarsiName,
                    cam.Complications)
            ),
            medicalInfo.OtherMedicines.Select(om =>
                new OtherMedicineResponse(
                    om.Id,
                    new GetDefaultMedicineResponse(
                        om.Medicine?.Id.ToString() ?? om.UserMedicine?.Id.ToString(),
                        om.Medicine?.Name ?? om.UserMedicine?.Name,
                        om.Medicine?.Type ?? om.UserMedicine?.Type),
                    om.Amount,
                    om.DateTimeUnitType?.FarsiName, 
                    om.DurationOfUseType?.FarsiName,
                    om.Complications)
            ),
            medicalInfo.EegDate,
            medicalInfo.EegResult,
            medicalInfo.PhotoResult,
            medicalInfo.PhotoDate,
            medicalInfo.OtherDiagnosticMeasuresDate,
            medicalInfo.OtherDiagnosticMeasuresResult,
            medicalInfo.FirstSeizure,
            medicalInfo.LastSeizure,
            medicalInfo.YearlySeizureCount,
            medicalInfo.SeizureInterval,
            medicalInfo.SeizureTimeUnit?.FarsiName,
            medicalInfo.ParentFamilyRelationship?.FarsiName,
            medicalInfo.HospitalizationDate,
            medicalInfo.HospitalizationCount,
            medicalInfo.HospitalizationDuration,
            medicalInfo.HospitalizationTimeUnit?.FarsiName,
            medicalInfo.SystemicDisease,
            medicalInfo.PastYearComplaints.Select(pyc => pyc.FarsiName),
            medicalInfo.FamilyDiseaseHistory.Select(fdh =>
                new FamilyDiseaseHistoryDTO(
                    fdh.Id,
                    fdh.FamilyDiseasesHistoryTypeId,
                    fdh.Name,
                    fdh.Relationship)
            ),
            medicalInfo.DrugConsumption.Select(dc =>
                new DrugConsumptionDTO(
                    dc.Id,
                    dc.DrugTypeId,
                    dc.DailyAmount,
                    dc.DrugConsumptionDuration,
                    dc.DateTimeUnitTypeId)
            ),
            medicalInfo.FamilyDescription,
            new SystemFileDTO(medicalInfo.FaceFilePath, medicalInfo.FaceFileUrl),
            new SystemFileDTO(medicalInfo.IdCardFilePath, medicalInfo.IdCardFileUrl)
        );
        }
    }
}
