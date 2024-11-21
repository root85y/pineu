namespace Pineu.Application.MainDomain.ScoreLogs.Commands.Validators {
    public class AddScoreLogCommandValidator : AbstractValidator<AddScoreLogCommand> {
        public AddScoreLogCommandValidator() {
            RuleFor(s => s.UserId).NotEmpty();
            RuleFor(s => s.Change).NotNull();
            RuleFor(s => s.RemainingScore).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(s => s.Action).IsInEnum();
            RuleFor(s => s.DiscountId).NotEmpty().When(s => s.Action == ScoreAction.BuyDiscount);
        }
    }
}
