namespace Pineu.Application.MainDomain.DoctorPrescriptions.Queries.DTOs;
public sealed record GetAllDoctorPrescriptionsResponse(string DoctorName, string VisitContent, DateTime VisitedAt);
