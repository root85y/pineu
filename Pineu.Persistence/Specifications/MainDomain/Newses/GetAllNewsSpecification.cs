namespace Pineu.Persistence.Specifications.MainDomain.Newses {
    internal class GetAllNewsSpecification : Specification<News> {
        public GetAllNewsSpecification(string? search) {
            if (!string.IsNullOrWhiteSpace(search))
                Query.Where(n => n.Title.Contains(search) || n.Body.Contains(search));
            Query.AsNoTracking().OrderByDescending(n => n.CreatedAt);
        }
    }
}
