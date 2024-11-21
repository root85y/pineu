namespace Pineu.Application.MainDomain.DoctorPrescriptions.Commands.Validators;
public class AddDoctorPrescriptionCommandValidator : AbstractValidator<AddDoctorPrescriptionCommand> {
    public AddDoctorPrescriptionCommandValidator() {
        RuleFor(d => d.DoctorName).NotEmpty();
        RuleFor(d => d.VisitContent).NotEmpty();
        RuleFor(d => d.VisitedAt).NotEmpty();
        RuleFor(d => d.UserId).NotEmpty();
    }
}
