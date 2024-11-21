namespace Pineu.Persistence.Specifications.SystemFiles;

internal class SystemFileGetByIdSpecification : SingleResultSpecification<SystemFile> {
    public SystemFileGetByIdSpecification(Guid criteriaId) {
        //AddInclude(criteria => criteria.Id == criteriaId);
        Query.Where(criteria => criteria.Id == criteriaId)
            .AsSplitQuery();
    }
}