using Pineu.Application.MainDomain.NutritionStatuses.Queries.DTOs;

namespace Pineu.Application.MainDomain.Patient.Queries.DTOs {
    public sealed record GetAllNutritionStatusesForPatientResponse(DateOnly Date, IEnumerable<DefaultIngredientObject> DefaultIngredients,
        IEnumerable<UserIngredientObject> UserIngredients);
}
