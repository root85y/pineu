namespace Pineu.Application.MainDomain.MedicalInformations.Commands.Validators;
public class UpsertMedicalInformationCommandValidator : AbstractValidator<UpsertMedicalInformationCommand> {
    public UpsertMedicalInformationCommandValidator() {
        RuleFor(m => m.UserId).NotEmpty();
        RuleForEach(m => m.Value.PastAntiepilepticMedicineList).SetValidator(new DrugValidator());
        RuleForEach(m => m.Value.CurrentAntiepilepticMedicineList).SetValidator(new DrugValidator());
        RuleForEach(m => m.Value.OtherMedicineList).SetValidator(new DrugValidator());
    }
}

public class DrugValidator : AbstractValidator<DrugDto> {
    public DrugValidator() {
        RuleFor(pam => pam.MedicineId).Must(IsIdValid);
    }

    private bool IsIdValid(string id) {
        return Guid.TryParse(id, out _) || int.TryParse(id, out _);
    }
}