namespace Pineu.Application.MainDomain.Discounts.Commands.Validators;
internal class UpdateDiscountCommandValidator : AbstractValidator<UpdateDiscountCommand> {
    public UpdateDiscountCommandValidator() {
        RuleFor(d => d.Id).NotEmpty();
        RuleFor(d => d.Description).NotEmpty();
        RuleFor(d => d.Title).NotEmpty();
        RuleFor(d => d.OffPercentage).NotEmpty().GreaterThan(0).LessThanOrEqualTo(100);
        RuleFor(d => d.ExpiresAt).NotEmpty();
        RuleFor(d => d.ScoreCost).NotEmpty();
        RuleFor(d => d.StoreId).NotEmpty();
    }
}
