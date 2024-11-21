namespace Pineu.Application.MainDomain.Banners.Commands.Validators;
public class UpdateBannerCommandValidator : AbstractValidator<UpdateBannerCommand> {
    public UpdateBannerCommandValidator() {
        RuleFor(b => b.Id).NotEmpty();
        RuleFor(b => b.Title).NotEmpty();
        RuleFor(b => b.Link).NotEmpty();
        RuleFor(b => b.ImageId).NotEmpty();
    }
}
