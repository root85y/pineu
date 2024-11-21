namespace Pineu.Application.MainDomain.NutritionStatuses.Commands {
    public sealed record UpsertNutritionStatusCommand(
        Guid UserId,
        IEnumerable<int> DefaultIngredients,
        IEnumerable<Guid> UserIngredients,
        DateTime Date) : ICommand;
}
