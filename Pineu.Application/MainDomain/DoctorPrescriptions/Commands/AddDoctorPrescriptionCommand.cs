namespace Pineu.Application.MainDomain.DoctorPrescriptions.Commands;
public sealed record AddDoctorPrescriptionCommand(Guid UserId, string DoctorName, string VisitContent, DateTime VisitedAt) : ICommand<Guid>;
