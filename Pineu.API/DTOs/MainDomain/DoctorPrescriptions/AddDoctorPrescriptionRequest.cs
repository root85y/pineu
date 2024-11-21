namespace Pineu.API.DTOs.MainDomain.DoctorPrescriptions {
    public sealed record AddDoctorPrescriptionRequest(string DoctorName, string VisitContent, DateTime VisitedAt);
}
