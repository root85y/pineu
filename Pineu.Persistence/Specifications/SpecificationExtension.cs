namespace Pineu.Persistence.Specifications;

public static class SpecificationExtension {
    public static void ToPaged<T>(this Specification<T> specification, int page, int size) {
        specification.Query
            .Skip((page - 1) * size)
            .Take(size);
    }
}