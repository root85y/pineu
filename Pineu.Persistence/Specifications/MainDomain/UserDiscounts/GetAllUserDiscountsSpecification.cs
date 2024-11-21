namespace Pineu.Persistence.Specifications.MainDomain.UserDiscounts {
    internal class GetAllUserDiscountsSpecification : Specification<UserDiscount> {
        public GetAllUserDiscountsSpecification(Guid? userId) {
            if (userId.HasValue)
                Query.Where(u => u.UserId == userId);
            Query.Include(u => u.Discount).AsNoTracking().OrderByDescending(u => u.CreatedAt);
        }
    }
}
