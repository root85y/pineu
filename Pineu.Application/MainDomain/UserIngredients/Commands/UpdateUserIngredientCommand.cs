namespace Pineu.Application.MainDomain.UserIngredients.Commands {
    public sealed record UpdateUserIngredientCommand(Guid Id, Guid UserId, string Name, IngredientCategory Category) : ICommand;
}
