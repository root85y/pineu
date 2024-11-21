using Pineu.Application.Medical.CurrentAntiepilepticMedicines.Commands;
using Pineu.Application.Medical.DrugConsumptions.Commands;
using Pineu.Application.Medical.FamilyDiseaseHistories.Commands;
using Pineu.Application.Medical.OtherMedicines.Commands;
using Pineu.Application.Medical.PastAntiepilepticMedicines.Commands;
using Pineu.Domain.Entities.Medical;
using Pineu.Domain.Repositories.Types;

namespace Pineu.Application.MainDomain.MedicalInformations.Commands.Handlers;
internal class UpsertMedicalInformationCommandHandler(IMedicalInformationRepository repository,
    IAetiologyTypeRepository aetiologyTypeRepository,
    IOtherDiseaseTypeRepository otherDiseaseTypeRepository,
    IPastYearComplaintTypeRepository pastYearComplaintTypeRepository,
    ISender sender)
    : ICommandHandler<UpsertMedicalInformationCommand> {
    public async Task<Result> Handle(UpsertMedicalInformationCommand request, CancellationToken cancellationToken) {
        var thisRequest = request.Value;
        var medicalInformation = await repository.GetAsync(request.UserId, cancellationToken);
        var aetiologies = await aetiologyTypeRepository.GetAllAsync(thisRequest.AetiologyList, null, cancellationToken);
        var otherDisease = await otherDiseaseTypeRepository.GetAllAsync(thisRequest.OtherDiseaseList, null, cancellationToken);
        var pastYearComplaints = await pastYearComplaintTypeRepository.GetAllAsync(thisRequest.PastYearComplaintList, null, cancellationToken);

        var medicalInformationId = Guid.NewGuid();
        if (medicalInformation != null)
            medicalInformationId = medicalInformation.Id;

        if (medicalInformation == null) {
            var pastAntiepilepticMedicines = thisRequest.PastAntiepilepticMedicineList.Select(pam =>
            PastAntiepilepticMedicine.Create(
            pam.Id ?? Guid.NewGuid(),
            int.TryParse(pam.MedicineId, out var userMedicineId) ? userMedicineId : null,
            Guid.TryParse(pam.MedicineId, out var medicineId) ? medicineId : null,
            pam.Amount,
            pam.DateTimeUnitTypeId,
            pam.DurationOfUseTypeId,
            pam.StopDate.HasValue ? DateOnly.FromDateTime(pam.StopDate.Value) : null,
            pam.ReasonOfStop,
            medicalInformationId)
            );
            var currentAntiepilepticMedicines = thisRequest.CurrentAntiepilepticMedicineList.Select(cam =>
            CurrentAntiepilepticMedicine.Create(
            cam.Id ?? Guid.NewGuid(),
            int.TryParse(cam.MedicineId, out var userMedicineId) ? userMedicineId : null,
            Guid.TryParse(cam.MedicineId, out var medicineId) ? medicineId : null,
            cam.Amount,
            cam.DateTimeUnitTypeId,
            cam.DurationOfUseTypeId,
            cam.Complications,
            medicalInformationId)
            );
            var otherMedicine = thisRequest.OtherMedicineList.Select(om =>
            OtherMedicine.Create(
            om.Id ?? Guid.NewGuid(),
            int.TryParse(om.MedicineId, out var userMedicineId) ? userMedicineId : null,
            Guid.TryParse(om.MedicineId, out var medicineId) ? medicineId : null,
            om.Amount,
            om.DateTimeUnitTypeId,
            om.DurationOfUseTypeId,
            om.Complications,
            medicalInformationId)
            );
            var familyDiseaseHistory = thisRequest.FamilyDiseaseHistoryList.Select(fdh =>
            FamilyDiseaseHistory.Create(
            fdh.Id ?? Guid.NewGuid(),
            fdh.FamilyDiseaseHistoryTypeId,
            fdh.Name,
            fdh.Relationship,
            medicalInformationId));
            var drugConsumption = thisRequest.DrugConsumptionList.Select(dc =>
            DrugConsumption.Create(
            dc.Id ?? Guid.NewGuid(),
            dc.DrugTypeId,
            dc.DailyAmount,
            dc.DrugConsumptionDuration,
            dc.DateTimeUnitTypeId,
            medicalInformationId));
            var newMedicalInformation = MedicalInformation.Create(
                medicalInformationId,
                request.UserId,
                thisRequest.DiagnosisDate.HasValue ? DateOnly.FromDateTime(thisRequest.DiagnosisDate.Value) : null,
                thisRequest.EpilepsyTypeId,
                thisRequest.SeizureSymptomList,
                thisRequest.SeizureSymptomFrequency,
                thisRequest.SeizureSymptomFrequencyTypeId,
                thisRequest.SeizureInjuryList,
                thisRequest.EpilepsyConsciousnessTypeId,
                thisRequest.EpilepsyMovementTypeId,
                thisRequest.EpilepsySecondType,
                thisRequest.SeizureTypeId,
                thisRequest.SeizureConsciousnessTypeId,
                thisRequest.SeizureMovementTypeId,
                thisRequest.SeizureSecondType,
                thisRequest.EpilepticSyndrome,
                aetiologies.ToList(),
                thisRequest.AetiologyDescription,
                otherDisease.ToList(),
                pastAntiepilepticMedicines.ToList(),
                currentAntiepilepticMedicines.ToList(),
                otherMedicine.ToList(),
                thisRequest.EegDate.HasValue ? DateOnly.FromDateTime(thisRequest.EegDate.Value) : null,
                thisRequest.EegResult,
                thisRequest.PhotoResult,
                thisRequest.PhotoDate.HasValue ? DateOnly.FromDateTime(thisRequest.PhotoDate.Value) : null,
                thisRequest.OtherDiagnosticMeasuresDate.HasValue ? DateOnly.FromDateTime(thisRequest.OtherDiagnosticMeasuresDate.Value) : null,
                thisRequest.OtherDiagnosticMeasuresResult,
                thisRequest.FirstSeizure.HasValue ? DateOnly.FromDateTime(thisRequest.FirstSeizure.Value) : null,
                thisRequest.LastSeizure.HasValue ? DateOnly.FromDateTime(thisRequest.LastSeizure.Value) : null,
                thisRequest.YearlySeizureCount,
                thisRequest.SeizureInterval,
                thisRequest.SeizureTimeUnitTypeId,
                thisRequest.ParentFamilyRelationshipTypeId,
                thisRequest.HospitalizationDate.HasValue ? DateOnly.FromDateTime(thisRequest.HospitalizationDate.Value) : null,
                thisRequest.HospitalizationCount,
                thisRequest.HospitalizationDuration,
                thisRequest.HospitalizationTimeUnitTypeId,
                thisRequest.SystemicDisease,
                pastYearComplaints.ToList(),
                familyDiseaseHistory.ToList(),
                drugConsumption.ToList(),
                thisRequest.FamilyDescription,
                thisRequest.FaceFile?.Path,
                thisRequest.FaceFile?.Url,
                thisRequest.IdCardFile?.Path,
                thisRequest.IdCardFile?.Url
            );
            await repository.AddAsync(newMedicalInformation, cancellationToken);
        } else {
            medicalInformation.Update(
                thisRequest.DiagnosisDate.HasValue ? DateOnly.FromDateTime(thisRequest.DiagnosisDate.Value) : null,
                thisRequest.EpilepsyTypeId,
                thisRequest.SeizureSymptomList,
                thisRequest.SeizureSymptomFrequency,
                thisRequest.SeizureSymptomFrequencyTypeId,
                thisRequest.SeizureInjuryList,
                thisRequest.EpilepsyConsciousnessTypeId,
                thisRequest.EpilepsyMovementTypeId,
                thisRequest.EpilepsySecondType,
                thisRequest.SeizureTypeId,
                thisRequest.SeizureConsciousnessTypeId,
                thisRequest.SeizureMovementTypeId,
                thisRequest.SeizureSecondType,
                thisRequest.EpilepticSyndrome,
                aetiologies.ToList(),
                thisRequest.AetiologyDescription,
                otherDisease.ToList(),
                //medicalInformation.PastAntiepilepticMedicines,
                //medicalInformation.CurrentAntiepilepticMedicines,
                //medicalInformation.OtherMedicines,
                //pastAntiepilepticMedicines.ToList(),
                //currentAntiepilepticMedicines.ToList(),
                //otherMedicine.ToList(),
                thisRequest.EegDate.HasValue ? DateOnly.FromDateTime(thisRequest.EegDate.Value) : null,
                thisRequest.EegResult,
                thisRequest.PhotoResult,
                thisRequest.PhotoDate.HasValue ? DateOnly.FromDateTime(thisRequest.PhotoDate.Value) : null,
                thisRequest.OtherDiagnosticMeasuresDate.HasValue ? DateOnly.FromDateTime(thisRequest.OtherDiagnosticMeasuresDate.Value) : null,
                thisRequest.OtherDiagnosticMeasuresResult,
                thisRequest.FirstSeizure.HasValue ? DateOnly.FromDateTime(thisRequest.FirstSeizure.Value) : null,
                thisRequest.LastSeizure.HasValue ? DateOnly.FromDateTime(thisRequest.LastSeizure.Value) : null,
                thisRequest.YearlySeizureCount,
                thisRequest.SeizureInterval,
                thisRequest.SeizureTimeUnitTypeId,
                thisRequest.ParentFamilyRelationshipTypeId,
                thisRequest.HospitalizationDate.HasValue ? DateOnly.FromDateTime(thisRequest.HospitalizationDate.Value) : null,
                thisRequest.HospitalizationCount,
                thisRequest.HospitalizationDuration,
                thisRequest.HospitalizationTimeUnitTypeId,
                thisRequest.SystemicDisease,
                pastYearComplaints.ToList(),
                //medicalInformation.FamilyDiseaseHistory,
                //medicalInformation.DrugConsumption,
                //familyDiseaseHistory.ToList(),
                //drugConsumption.ToList(),
                thisRequest.FamilyDescription,
                thisRequest.FaceFile?.Path,
                thisRequest.FaceFile?.Url,
                thisRequest.IdCardFile?.Path,
                thisRequest.IdCardFile?.Url);
            await repository.UpdateAsync(medicalInformation, cancellationToken);
            
            var pamIds = thisRequest.PastAntiepilepticMedicineList.Select(pam => pam.Id).ToList();
            var pamListToRemove = medicalInformation.PastAntiepilepticMedicines.
                Where(item => !pamIds.Contains(item.Id)).Select(item => item.Id);
            List<PastAntiepilepticMedicineDTO> pamListToAdd = [];
            List<PastAntiepilepticMedicineDTO> pamListToUpdate = [];
            foreach (var item in thisRequest.PastAntiepilepticMedicineList) {
                if (item.Id == null) {
                    pamListToAdd.Add(item);
                } else {
                    pamListToUpdate.Add(item);
                }
            }
            var res = await sender.Send(new DeletePastAntiepilepticMedicineCommand(pamListToRemove), cancellationToken);
            res = await sender.Send(new AddPastAntiepilepticMedicineCommand(pamListToAdd, medicalInformationId), cancellationToken);
            res = await sender.Send(new UpdatePastAntiepilepticMedicineCommand(pamListToUpdate), cancellationToken);

            var camIds = thisRequest.CurrentAntiepilepticMedicineList.Select(pam => pam.Id).ToList();
            var camListToRemove = medicalInformation.CurrentAntiepilepticMedicines.
                Where(item => !camIds.Contains(item.Id)).Select(item => item.Id);
            List<CurrentAntiepilepticMedicineDTO> camListToAdd = [];
            List<CurrentAntiepilepticMedicineDTO> camListToUpdate = [];
            foreach (var item in thisRequest.CurrentAntiepilepticMedicineList) {
                if (item.Id == null) {
                    camListToAdd.Add(item);
                } else {
                    camListToUpdate.Add(item);
                }
            }
            res = await sender.Send(new DeleteCurrentAntiepilepticMedicineCommand(camListToRemove), cancellationToken);
            res = await sender.Send(new AddCurrentAntiepilepticMedicineCommand(camListToAdd, medicalInformationId), cancellationToken);
            res = await sender.Send(new UpdateCurrentAntiepilepticMedicineCommand(camListToUpdate), cancellationToken);

            var omIds = thisRequest.OtherMedicineList.Select(pam => pam.Id).ToList();
            var omListToRemove = medicalInformation.OtherMedicines.
                Where(item => !omIds.Contains(item.Id)).Select(item => item.Id);
            List<OtherMedicineDTO> omListToAdd = [];
            List<OtherMedicineDTO> omListToUpdate = [];
            foreach (var item in thisRequest.OtherMedicineList) {
                if (item.Id == null) {
                    omListToAdd.Add(item);
                } else {
                    omListToUpdate.Add(item);
                }
            } 
            res = await sender.Send(new DeleteOtherMedicineCommand(omListToRemove), cancellationToken);
            res = await sender.Send(new AddOtherMedicineCommand(omListToAdd, medicalInformationId), cancellationToken);
            res = await sender.Send(new UpdateOtherMedicineCommand(omListToUpdate), cancellationToken);

            var dcIds = thisRequest.DrugConsumptionList.Select(pam => pam.Id).ToList();
            var dcListToRemove = medicalInformation.DrugConsumption.
                Where(item => !dcIds.Contains(item.Id)).Select(item => item.Id);
            List<DrugConsumptionDTO> dcListToAdd = [];
            List<DrugConsumptionDTO> dcListToUpdate = [];
            foreach (var item in thisRequest.DrugConsumptionList) {
                if (item.Id == null) {
                    dcListToAdd.Add(item);
                } else {
                    dcListToUpdate.Add(item);
                }
            }
            res = await sender.Send(new DeleteDrugConsumptionCommand(dcListToRemove), cancellationToken);
            res = await sender.Send(new AddDrugConsumptionCommand(dcListToAdd, medicalInformationId), cancellationToken);
            res = await sender.Send(new UpdateDrugConsumptionCommand(dcListToUpdate), cancellationToken);

            var fdhIds = thisRequest.FamilyDiseaseHistoryList.Select(pam => pam.Id).ToList();
            var fdhListToRemove = medicalInformation.FamilyDiseaseHistory.
                Where(item => !fdhIds.Contains(item.Id)).Select(item => item.Id);
            List<FamilyDiseaseHistoryDTO> fdhListToAdd = [];
            List<FamilyDiseaseHistoryDTO> fdhListToUpdate = [];
            foreach (var item in thisRequest.FamilyDiseaseHistoryList) {
                if (item.Id == null) {
                    fdhListToAdd.Add(item);
                } else {
                    fdhListToUpdate.Add(item);
                }
            }
            res = await sender.Send(new DeleteFamilyDiseaseHistoryCommand(fdhListToRemove), cancellationToken);
            res = await sender.Send(new AddFamilyDiseaseHistoryCommand(fdhListToAdd, medicalInformationId), cancellationToken);
            res = await sender.Send(new UpdateFamilyDiseaseHistoryCommand(fdhListToUpdate), cancellationToken);
        }
        return Result.Success();
    }
}
