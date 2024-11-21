namespace Pineu.Persistence.Specifications.MainDomain.NutritionStatuses {
    internal class GetNutritionStatusByUserIdSpecification : Specification<NutritionStatus> {
        public GetNutritionStatusByUserIdSpecification(Guid userId, DateTime? date) {
            if (date.HasValue)
                Query.Where(ms => ms.Date == DateOnly.FromDateTime(date.Value));
            else
                Query.Where(ms => ms.Date == DateOnly.FromDateTime(DateTime.Now));
            Query.Where(ms => ms.UserId == userId)
                .Include(ms => ms.Ingredients)
                .Include(ms => ms.UserIngredients);
        }
    }
}
