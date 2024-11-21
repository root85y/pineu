
namespace Pineu.Application.MainDomain.UserIngredients.Commands.Handlers {
    internal class UpdateUserIngredientCommandHandler(IUserIngredientRepository repository) 
        : ICommandHandler<UpdateUserIngredientCommand> {
        public async Task<Result> Handle(UpdateUserIngredientCommand request, CancellationToken cancellationToken) {
            var userIngredient = await repository.GetAsync(request.Id, cancellationToken);
            if (userIngredient == null) return Result.Failure(DomainErrors.UserIngredient.UserIngredientNotFound);

            userIngredient.Update(request.Name, request.Category);
            await repository.UpdateAsync(userIngredient, cancellationToken);
            return Result.Success();
        }
    }
}
