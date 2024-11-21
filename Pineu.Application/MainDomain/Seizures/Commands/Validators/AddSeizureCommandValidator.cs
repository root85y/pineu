namespace Pineu.Application.MainDomain.Seizures.Commands.Validators {
    public class AddSeizureCommandValidator : AbstractValidator<AddSeizureCommand> {
        public AddSeizureCommandValidator() {
            RuleFor(s => s.SeizureDateTime).NotEmpty();
            RuleFor(s => s.UserId).NotEmpty();
            RuleFor(s => s.SeizureDuration).GreaterThan(0);
            RuleForEach(s => s.AttackTypeList).IsInEnum();
            RuleFor(s => s.MentalStatusBeforeSeizure).IsInEnum();
            RuleFor(s => s.AmountOfPhysicalStatusBeforeSeizure).IsInEnum();
            RuleFor(s => s.SleepQualityAtTheNightBeforeSeizure).IsInEnum();
            RuleFor(s => s.AmountOfFoodBeforeSeizure).IsInEnum();
            RuleFor(s => s.SmokingConsumption).IsInEnum();
            RuleFor(s => s.AlcoholConsumption).IsInEnum();
            RuleFor(s => s.MentalStatusAfterSeizure).IsInEnum();
        }
    }
}
