namespace Pineu.Domain.Entities.MainDomain;
public class DoctorPrescription : Entity<Guid> {
    public string DoctorName { get; private set; }
    public string VisitContent { get; private set; }
    public DateTime VisitedAt { get; private set; }

    public Guid UserId { get; private set; }

    private DoctorPrescription(Guid id) : base(id) { }
    private DoctorPrescription(Guid id, string doctorName, string visitContent, DateTime visitedAt, Guid userId) : this(id) {
        DoctorName = doctorName;
        VisitContent = visitContent;
        VisitedAt = visitedAt;
        UserId = userId;
    }

    public static DoctorPrescription Create(Guid id, string doctorName, string visitContent, DateTime visitedAt, Guid userId) =>
        new(id, doctorName, visitContent, visitedAt, userId);

    public void Update(string doctorName, string visitContent, DateTime visitedAt) {
        DoctorName = doctorName;
        VisitContent = visitContent;
        VisitedAt = visitedAt;
    }
}
