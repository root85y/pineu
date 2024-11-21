namespace Pineu.Persistence.Specifications.MainDomain.Discounts {
    internal class GetAllDiscountsSpecification : Specification<Discount> {
        public GetAllDiscountsSpecification(string? search, Guid? storeId, Guid? userId) {
            if (!string.IsNullOrWhiteSpace(search))
                Query.Where(d => d.Title.Contains(search) || d.Description.Contains(search));
            if (storeId.HasValue)
                Query.Where(d => d.StoreId == storeId);
            if (userId.HasValue)
                Query.Where(d => !d.UserDiscounts.Any(ud => ud.UserId == userId));

            Query.AsNoTracking().OrderByDescending(d => d.CreatedAt);
        }
    }
}
