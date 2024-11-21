namespace Pineu.Application.MainDomain.Banners.Commands.Validators;
public class AddBannerCommandValidator : AbstractValidator<AddBannerCommand> {
    public AddBannerCommandValidator() {
        RuleFor(b => b.Title).NotEmpty();
        RuleFor(b => b.Link).NotEmpty();
        RuleFor(b => b.ImageId).NotEmpty();
    }
}
