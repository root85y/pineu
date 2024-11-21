namespace Pineu.Application.MainDomain.UserMedicines.Commands.Validators
{
    public class UpdateUserMedicineCommandValidator : AbstractValidator<UpdateUserMedicineCommand>
    {
        public UpdateUserMedicineCommandValidator()
        {
            RuleFor(um => um.Id).NotEmpty();
            RuleFor(um => um.Name).NotEmpty();
            RuleFor(um => um.Type).IsInEnum();
        }
    }
}
