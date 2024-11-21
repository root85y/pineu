namespace Pineu.Application.DbBackups.DatabaseBackups.Command.Validators;
public class DeleteDatabaseBackupCommandValidator : AbstractValidator<DeleteDatabaseBackupCommand> {
    public DeleteDatabaseBackupCommandValidator() {
        RuleFor(d => d.Id).NotEmpty();
    }
}
