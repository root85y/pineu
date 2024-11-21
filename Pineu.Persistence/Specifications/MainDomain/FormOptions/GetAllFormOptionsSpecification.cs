namespace Pineu.Persistence.Specifications.MainDomain.FormOptions {
    internal class GetAllFormOptionsSpecification : Specification<FormOption> {
        public GetAllFormOptionsSpecification(string? search, Guid? formItemId) {
            if (!string.IsNullOrEmpty(search))
                Query.Where(fo => fo.Label.Contains(search));
            if (formItemId.HasValue)
                Query.Where(fo => fo.FormItemId == formItemId.Value);

            Query.AsNoTracking().OrderByDescending(fo => fo.CreatedAt);
        }
    }
}
