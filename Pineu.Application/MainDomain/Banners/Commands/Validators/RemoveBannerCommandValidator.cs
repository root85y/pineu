namespace Pineu.Application.MainDomain.Banners.Commands.Validators;
public class RemoveBannerCommandValidator : AbstractValidator<RemoveBannerCommand> {
    public RemoveBannerCommandValidator() {
        RuleFor(b => b.Id).NotEmpty();
    }
}
