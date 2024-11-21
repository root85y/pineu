using Pineu.Application.MainDomain.NutritionStatuses.Queries;
using Pineu.Application.MainDomain.NutritionStatuses.Queries.DTOs;
using Pineu.Application.MainDomain.Patient.Queries.DTOs;
using Pineu.Application.MainDomain.Seizures.Queries;

namespace Pineu.Application.MainDomain.Patient.Queries.Handlers {
    internal class GetAllNutritionStatusesForPatientQueryHandler(INutritionStatusRepository repository, ISender sender)
        : IQueryHandler<GetAllNutritionStatusesForPatientQuery, PagedResponse<IEnumerable<GetAllNutritionStatusesForPatientResponse>>> {
        public async Task<Result<PagedResponse<IEnumerable<GetAllNutritionStatusesForPatientResponse>>>> Handle(GetAllNutritionStatusesForPatientQuery request, CancellationToken cancellationToken) {
            var nutritionStatuses = await repository.GetAllForPatientAsync(request.From, request.To, request.UserId,
                cancellationToken);

            var res = nutritionStatuses.List.Select(ns => new GetAllNutritionStatusesForPatientResponse(
                ns.Date,
                ns.Ingredients.Select(i => new DefaultIngredientObject(
                    i.Id.ToString(), new Label(i.FarsiLabel, i.EnglishLabel), i.Category)),
                ns.UserIngredients.Select(ui => new UserIngredientObject(ui.Id.ToString(), ui.Name, ui.Category))
                ));
            return new PagedResponse<IEnumerable<GetAllNutritionStatusesForPatientResponse>>(res, nutritionStatuses.Count);
        }
    }
}
