namespace Pineu.Persistence.Specifications.MainDomain.Discounts {
    internal class GetDiscountByIdSpecification : Specification<Discount> {
        public GetDiscountByIdSpecification(Guid id) {
            Query.Where(d => d.Id == id).Include(d => d.Store).AsSplitQuery();
        }
    }
}
