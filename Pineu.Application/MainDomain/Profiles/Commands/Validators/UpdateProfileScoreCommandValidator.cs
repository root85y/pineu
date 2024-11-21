namespace Pineu.Application.MainDomain.Profiles.Commands.Validators {
    public class UpdateProfileScoreCommandValidator : AbstractValidator<UpdateProfileScoreCommand> {
        public UpdateProfileScoreCommandValidator() {
            RuleFor(s => s.Action).IsInEnum();
            RuleFor(s => s.UserId).NotEmpty();
            RuleFor(s => s.DiscountId).NotEmpty().When(s => s.Action == ScoreAction.BuyDiscount);
        }
    }
}
