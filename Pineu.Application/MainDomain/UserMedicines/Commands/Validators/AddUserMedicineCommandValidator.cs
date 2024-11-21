namespace Pineu.Application.MainDomain.UserMedicines.Commands.Validators
{
    public class AddUserMedicineCommandValidator : AbstractValidator<AddUserMedicineCommand>
    {
        public AddUserMedicineCommandValidator()
        {
            RuleFor(um => um.Name).NotEmpty();
            RuleFor(um => um.Type).IsInEnum();
            RuleFor(um => um.UserId).NotEmpty();
        }
    }
}
