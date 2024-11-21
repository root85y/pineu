namespace Pineu.Application.DbBackups.DatabaseBackups.Command.Validators;
public class MakeDatabaseBackupCommandValidator : AbstractValidator<MakeDatabaseBackupCommand> {
    public MakeDatabaseBackupCommandValidator() {
        RuleFor(d => d.ContentRootPath).NotEmpty();
    }
}
