namespace Pineu.Application.MainDomain.UserIngredients.Commands {
    public sealed record AddUserIngredientCommand(Guid UserId, string Name, IngredientCategory Category) : ICommand<Guid>;
}
