namespace Pineu.Persistence.Specifications.MainDomain.Banners {
    internal class GetAllBannersSpecification : Specification<Banner> {
        public GetAllBannersSpecification(string? search) {
            if (!string.IsNullOrWhiteSpace(search))
                Query.Where(b => b.Title.Contains(search));

            Query.AsNoTracking().OrderByDescending(b => b.CreatedAt);
        }
    }
}
