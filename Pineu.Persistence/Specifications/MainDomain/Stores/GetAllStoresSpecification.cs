namespace Pineu.Persistence.Specifications.MainDomain.Stores {
    internal class GetAllStoresSpecification : Specification<Store> {
        public GetAllStoresSpecification(string? search) {
            if (!string.IsNullOrWhiteSpace(search))
                Query.Where(s => s.Title.Contains(search) || s.Address.Contains(search) || s.PhoneNumber.Contains(search));
            Query.Include(s => s.Discounts).AsNoTracking().OrderByDescending(s => s.CreatedAt);
        }
    }
}
