namespace Pineu.Persistence.Specifications.MainDomain.NutritionStatuses {
    internal class GetAllNutritionStatusesSpecification : Specification<NutritionStatus> {
        public GetAllNutritionStatusesSpecification(DateTime? from, DateTime? to, Guid? userId) {
            if (from.HasValue && to.HasValue) {
                Query.Where(s => s.Date >= DateOnly.FromDateTime(from.Value) && s.Date <= DateOnly.FromDateTime(to.Value));
            } else {
                Query.Where(s => s.Date >= DateOnly.FromDateTime(DateTime.Now.AddDays(-7)));
            }
            if (userId.HasValue)
                Query.Where(ms => ms.UserId == userId);
            Query.Include(ns => ns.Ingredients).Include(ns => ns.UserIngredients)
                .AsNoTracking().OrderByDescending(ms => ms.Date);
        }
    }
}
