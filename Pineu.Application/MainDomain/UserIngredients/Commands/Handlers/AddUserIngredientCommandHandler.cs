
namespace Pineu.Application.MainDomain.UserIngredients.Commands.Handlers {
    internal class AddUserIngredientCommandHandler(IUserIngredientRepository repository) 
        : ICommandHandler<AddUserIngredientCommand, Guid> {
        public async Task<Result<Guid>> Handle(AddUserIngredientCommand request, CancellationToken cancellationToken) {
            var userIngredient = UserIngredient.Create(request.UserId, request.Name, request.Category);
            await repository.AddAsync(userIngredient, cancellationToken);

            return userIngredient.Id;
        }
    }
}
