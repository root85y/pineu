using Shared.Constants.Enums;

namespace Pineu.Persistence.Specifications.MainDomain.FormItems {
    internal class GetAllFormItemsSpecification : Specification<FormItem> {
        public GetAllFormItemsSpecification(string? search, FormName? formName, FormItemTemplate? template) {
            if (formName.HasValue)
                Query.Where(fi => fi.Form == formName.Value);

            if (template.HasValue)
                Query.Where(fi => fi.Template == template.Value);

            if (!string.IsNullOrWhiteSpace(search))
                Query.Where(fi => fi.Name.Contains(search) || fi.Label.Contains(search));

            Query.AsNoTracking().OrderByDescending(b => b.CreatedAt);
        }
    }
}
