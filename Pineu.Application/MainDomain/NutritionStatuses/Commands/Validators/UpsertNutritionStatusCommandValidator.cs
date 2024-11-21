namespace Pineu.Application.MainDomain.NutritionStatuses.Commands.Validators {
    public class UpsertNutritionStatusCommandValidator : AbstractValidator<UpsertNutritionStatusCommand> {
        public UpsertNutritionStatusCommandValidator() {
            RuleFor(ns => DateOnly.FromDateTime(ns.Date)).NotEmpty().GreaterThan(DateOnly.FromDateTime(DateTime.Now.AddDays(-3)))
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now));
            RuleFor(ns => ns.UserId).NotEmpty();
        }
    }
}
