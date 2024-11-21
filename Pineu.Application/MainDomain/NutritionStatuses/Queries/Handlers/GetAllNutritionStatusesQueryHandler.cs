using Pineu.Application.MainDomain.NutritionStatuses.Queries.DTOs;
using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.Seizures.Queries;

namespace Pineu.Application.MainDomain.NutritionStatuses.Queries.Handlers {
    internal class GetAllNutritionStatusesQueryHandler(INutritionStatusRepository repository, ISender sender)
        : IQueryHandler<GetAllNutritionStatusesQuery, PagedResponse<IEnumerable<GetAllNutritionStatusesResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetAllNutritionStatusesResponse>>>> Handle(GetAllNutritionStatusesQuery request, CancellationToken cancellationToken) {
            var nutritionStatuses = await repository.GetAllAsync(request.From, request.To, request.Page, request.PageSize, request.UserId,
                cancellationToken);
            var seizures = await sender.Send(new GetAllSeizuresQuery(request.UserId, null, null, request.Page, request.PageSize),
                cancellationToken);

            var res = nutritionStatuses.List.Select(ns => new GetAllNutritionStatusesResponse(
                ns.Date,
                ns.Ingredients.Select(i => new DefaultIngredientObject(
                    i.Id.ToString(), new Label(i.FarsiLabel, i.EnglishLabel), i.Category)),
                ns.UserIngredients.Select(ui => new UserIngredientObject(ui.Id.ToString(), ui.Name, ui.Category)),
                seizures.Value.List.Any(s => DateOnly.FromDateTime(s.SeizureDateTime) == ns.Date)));
            return new PagedResponse<IEnumerable<GetAllNutritionStatusesResponse>>(res, nutritionStatuses.Count);
        }
    }
}
