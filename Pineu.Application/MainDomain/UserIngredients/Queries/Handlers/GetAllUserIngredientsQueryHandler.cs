using Pineu.Application.MainDomain.UserIngredients.Queries.DTOs;

namespace Pineu.Application.MainDomain.UserIngredients.Queries.Handlers {
    internal class GetAllUserIngredientsQueryHandler(IUserIngredientRepository repository)
        : IQueryHandler<GetAllUserIngredientsQuery, IEnumerable<GetUserIngredientResponse>> {
        public async Task<Result<IEnumerable<GetUserIngredientResponse>>> Handle(GetAllUserIngredientsQuery request, CancellationToken cancellationToken) {
            var userIngredients = await repository.GetAllAsync(request.UserId, request.Search,
                request.Category, null, cancellationToken);
            return userIngredients.Select(u => new GetUserIngredientResponse(u.Id, u.Name, u.Category)).ToList();
        }
    }
}
