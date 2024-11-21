namespace Pineu.Application.MainDomain.Banners.Commands.Validators;
public class ToggleBannerCommandValidator : AbstractValidator<ToggleBannerCommand> {
    public ToggleBannerCommandValidator() {
        RuleFor(b => b.Id).NotEmpty();
    }
}
