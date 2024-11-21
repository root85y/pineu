namespace Pineu.Domain.Shared;
public interface IValidationResult {
    public static readonly Error ValidationError = new(
        "A validation problem occurred.");

    Error[] Errors { get; }
}
